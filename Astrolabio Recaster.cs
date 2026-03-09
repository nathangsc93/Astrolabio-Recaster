using Astrolabio_Recaster.Models;
using Astrolabio_Recaster.Services;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;

namespace Astrolabio_Recaster
{
    public partial class Form1 : Form
    {
        private readonly ScreenCaptureService _screenCaptureService;
        private readonly OcrService _ocrService;
        private readonly StatParser _statParser;
        private readonly StatMatchService _statMatchService;

        private int _attemptCount = 0;
        private DateTime? _startTime = null;
        private System.Windows.Forms.Timer? _elapsedTimer = null;
        private bool _isRolling = false;

        private bool _clickCalibrated = false;
        private Point _rollButtonOffset = Point.Empty;
        private Point _dragStart;

        private const uint INPUT_MOUSE = 0;
        private const uint MOUSEEVENTF_MOVE = 0x0001;
        private const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int HOTKEY_ID_STOP = 1;
        private const int WM_HOTKEY = 0x0312;
        private const uint MOD_NONE = 0x0000;
        private const uint VK_F8 = 0x77;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID_STOP)
            {
                if (_isRolling)
                {
                    _isRolling = false;
                    StopAutomationStatus("Interrompido por F8");
                    Show();
                    Activate();
                    SetGeneralStatus("Automação interrompida por F8.");
                }
            }

            base.WndProc(ref m);
        }

        [DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public uint type;
            public InputUnion U;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public nint dwExtraInfo;
        }

        public Form1()
        {
            InitializeComponent();

            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AstrolabioRecaster.ico");
            if (File.Exists(iconPath))
            {
                this.Icon = new Icon(iconPath);
            }

            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = true;
            _screenCaptureService = new ScreenCaptureService();
            _ocrService = new OcrService(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata"));
            _statParser = new StatParser();
            _statMatchService = new StatMatchService();

            Load += Form1_Load;

            dgvDesiredStats.CellValueChanged += dgvDesiredStats_CellValueChanged;
            dgvDesiredStats.CurrentCellDirtyStateChanged += dgvDesiredStats_CurrentCellDirtyStateChanged;
            dgvDesiredStats.EditingControlShowing += dgvDesiredStats_EditingControlShowing;

            chkUnlimitedAttempts.CheckedChanged += chkUnlimitedAttempts_CheckedChanged;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            InitializeDesiredStatsGrid();
            LoadDesiredStatsGrid();
            StyleDesiredStatsGrid();
            InitializeAutomationStatus();
            UpdateClickCalibrationInfo();
            nudVisualDelay.Value = 5;

            nudMaxAttempts.Minimum = 1;
            nudMaxAttempts.Maximum = 999999;
            nudMaxAttempts.Value = 100;
            chkUnlimitedAttempts.Checked = false;

            btnStopRolling.Enabled = false;

            RegisterHotKey(Handle, HOTKEY_ID_STOP, MOD_NONE, VK_F8);

            SetGeneralStatus("Pronto.");
        }

        private void InitializeDesiredStatsGrid()
        {
            if (dgvDesiredStats.Columns["colQuantity"] is DataGridViewComboBoxColumn comboCol)
            {
                comboCol.FlatStyle = FlatStyle.Flat;
                comboCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                comboCol.DefaultCellStyle.BackColor = Color.FromArgb(18, 18, 18);
                comboCol.DefaultCellStyle.ForeColor = Color.White;
                comboCol.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 45);
                comboCol.DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }

        private void StyleDesiredStatsGrid()
        {
            dgvDesiredStats.BackgroundColor = Color.FromArgb(10, 10, 10);
            dgvDesiredStats.BorderStyle = BorderStyle.None;
            dgvDesiredStats.GridColor = Color.FromArgb(55, 55, 55);

            dgvDesiredStats.EnableHeadersVisualStyles = false;

            dgvDesiredStats.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvDesiredStats.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvDesiredStats.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDesiredStats.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dgvDesiredStats.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvDesiredStats.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            dgvDesiredStats.DefaultCellStyle.BackColor = Color.FromArgb(18, 18, 18);
            dgvDesiredStats.DefaultCellStyle.ForeColor = Color.White;
            dgvDesiredStats.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 45);
            dgvDesiredStats.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDesiredStats.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvDesiredStats.DefaultCellStyle.Padding = new Padding(2, 0, 2, 0);

            dgvDesiredStats.RowsDefaultCellStyle.BackColor = Color.FromArgb(18, 18, 18);
            dgvDesiredStats.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(22, 22, 22);

            dgvDesiredStats.RowHeadersVisible = false;
            dgvDesiredStats.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDesiredStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDesiredStats.ColumnHeadersHeight = 26;
            dgvDesiredStats.RowTemplate.Height = 24;

            if (dgvDesiredStats.Columns["colSelect"] != null)
                dgvDesiredStats.Columns["colSelect"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvDesiredStats.Columns["colQuantity"] != null)
                dgvDesiredStats.Columns["colQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void InitializeAutomationStatus()
        {
            _elapsedTimer = new System.Windows.Forms.Timer();
            _elapsedTimer.Interval = 1000;
            _elapsedTimer.Tick += ElapsedTimer_Tick;

            ResetAutomationStatus();
        }

        private void ResetAutomationStatus()
        {
            lblMatchedStatsValue.Text = "0 / 0";
            _attemptCount = 0;
            _startTime = null;
            _isRolling = false;

            lblStatusValue.Text = "Aguardando";
            lblAttemptsValue.Text = "0";
            lblElapsedValue.Text = "00:00:00";

            btnStartRolling.Enabled = true;
            btnStopRolling.Enabled = false;

            _elapsedTimer?.Stop();
        }

        private void StartAutomationStatus()
        {
            lblMatchedStatsValue.Text = "0 / 0";
            _attemptCount = 0;
            _startTime = DateTime.Now;
            _isRolling = true;

            lblStatusValue.Text = "Roletando";
            lblAttemptsValue.Text = "0";
            lblElapsedValue.Text = "00:00:00";

            btnStartRolling.Enabled = false;
            btnStopRolling.Enabled = true;

            _elapsedTimer?.Start();
        }

        private void StopAutomationStatus(string finalStatus)
        {
            _isRolling = false;
            lblStatusValue.Text = finalStatus;

            _elapsedTimer?.Stop();

            btnStartRolling.Enabled = true;
            btnStopRolling.Enabled = false;
        }

        private void IncrementAttemptCount()
        {
            _attemptCount++;
            lblAttemptsValue.Text = _attemptCount.ToString();
        }

        private void ElapsedTimer_Tick(object? sender, EventArgs e)
        {
            if (_startTime == null)
            {
                lblElapsedValue.Text = "00:00:00";
                return;
            }

            TimeSpan elapsed = DateTime.Now - _startTime.Value;
            lblElapsedValue.Text = elapsed.ToString(@"hh\:mm\:ss");
        }

        private bool HasReachedAttemptLimit()
        {
            if (chkUnlimitedAttempts.Checked)
                return false;

            return _attemptCount >= (int)nudMaxAttempts.Value;
        }

        private void chkUnlimitedAttempts_CheckedChanged(object? sender, EventArgs e)
        {
            nudMaxAttempts.Enabled = !chkUnlimitedAttempts.Checked;
        }

        private void SetGeneralStatus(string message)
        {
            lblStatus.Text = message;
        }

        private void UpdateClickCalibrationInfo()
        {
            lblClickCalibrationValue.Text = _clickCalibrated ? "Sim" : "Não";
            lblClickOffsetValue.Text = $"({_rollButtonOffset.X}, {_rollButtonOffset.Y})";
        }

        private Rectangle GetCaptureRectangle()
        {
            Point captureBase = picCapturedRegion.PointToScreen(Point.Empty);

            return new Rectangle(
                captureBase.X,
                captureBase.Y,
                picCapturedRegion.Width,
                picCapturedRegion.Height
            );
        }

        private Point GetRollButtonScreenPoint()
        {
            Rectangle captureRect = GetCaptureRectangle();

            return new Point(
                captureRect.X + _rollButtonOffset.X,
                captureRect.Y + _rollButtonOffset.Y
            );
        }

        private Bitmap ResizeBitmap(Bitmap source, int width, int height)
        {
            Bitmap result = new(width, height);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(source, 0, 0, width, height);
            }

            return result;
        }

        private (string ocrText, List<string> detectedStats) ReadBestOcrResult(Bitmap original)
        {
            string bestText = string.Empty;
            List<string> bestStats = new();

            string text1 = _ocrService.ReadText(original);
            List<string> stats1 = _statParser.ParseStats(text1);

            bestText = text1;
            bestStats = stats1;

            using (Bitmap enlarged = ResizeBitmap(original, original.Width * 2, original.Height * 2))
            {
                string text2 = _ocrService.ReadText(enlarged);
                List<string> stats2 = _statParser.ParseStats(text2);

                if (stats2.Count > bestStats.Count)
                {
                    bestText = text2;
                    bestStats = stats2;
                }
            }

            return (bestText, bestStats);
        }

        private async Task<(string ocrText, List<string> detectedStats)> CaptureAndAnalyzeAsync(bool hideForm = true)
        {
            Rectangle captureRect = GetCaptureRectangle();
            Bitmap? capture = null;

            try
            {
                if (hideForm)
                {
                    Hide();
                    await Task.Delay(200);
                }

                capture = _screenCaptureService.CaptureRegion(captureRect);
            }
            finally
            {
                if (hideForm)
                {
                    Show();
                    Activate();
                }
            }

            Bitmap preview = (Bitmap)capture.Clone();

            picCapturedRegion.Image?.Dispose();
            picCapturedRegion.Image = preview;
            picCapturedRegion.Refresh();

            await Task.Delay(50);

            var result = ReadBestOcrResult(capture);

            txtOcrRaw.Text = result.ocrText;

            lstStats.Items.Clear();
            foreach (string stat in result.detectedStats)
                lstStats.Items.Add(stat);

            txtOcrRaw.Refresh();
            lstStats.Refresh();

            capture.Dispose();
            return result;
        }

        private List<DesiredStat> GetDesiredStats()
        {
            List<DesiredStat> desiredStats = new();

            foreach (DataGridViewRow row in dgvDesiredStats.Rows)
            {
                bool selected = row.Cells["colSelect"].Value is bool b && b;
                if (!selected)
                    continue;

                string name = row.Cells["colStatName"].Value?.ToString() ?? string.Empty;

                int quantity = 1;
                int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out quantity);
                if (quantity < 1)
                    quantity = 1;

                desiredStats.Add(new DesiredStat
                {
                    Name = name,
                    Quantity = quantity
                });
            }

            return desiredStats;
        }

        private void LoadDesiredStatsGrid()
        {
            dgvDesiredStats.Rows.Clear();

            string[] stats =
            {
                "Atq Físico",
                "Atq Mágico",
                "Pen. Física",
                "Pen. Mágica",
                "Def",
                "DefM",
                "HP",
                "MP",
                "Espírito",
                "Def Metal",
                "Def Madeira",
                "Def Água",
                "Def Fogo",
                "Def Terra",
                "Acerto",
                "Esquiva"
            };

            foreach (string stat in stats)
            {
                int rowIndex = dgvDesiredStats.Rows.Add();
                DataGridViewRow row = dgvDesiredStats.Rows[rowIndex];

                row.Cells["colSelect"].Value = false;
                row.Cells["colStatName"].Value = stat;
                row.Cells["colQuantity"].Value = "1";
            }

            UpdateSelectedCount();
        }

        private void UpdateSelectedCount()
        {
            int total = 0;

            foreach (DataGridViewRow row in dgvDesiredStats.Rows)
            {
                bool selected = row.Cells["colSelect"].Value is bool b && b;
                if (!selected)
                    continue;

                string qtyText = row.Cells["colQuantity"].Value?.ToString() ?? "1";

                if (int.TryParse(qtyText, out int qty))
                    total += qty;
            }

            lblSelectedCount.Text = $"Total selecionado: {total} / 10";
        }

        private bool ValidateSelectedTotal()
        {
            int total = 0;

            foreach (DataGridViewRow row in dgvDesiredStats.Rows)
            {
                bool selected = row.Cells["colSelect"].Value is bool b && b;
                if (!selected)
                    continue;

                string qtyText = row.Cells["colQuantity"].Value?.ToString() ?? "1";

                if (int.TryParse(qtyText, out int qty))
                    total += qty;
            }

            return total <= 10;
        }

        private void dgvDesiredStats_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (!ValidateSelectedTotal())
            {
                MessageBox.Show(
                    "O total de atributos desejados não pode ultrapassar 10.",
                    "Limite excedido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                string columnName = dgvDesiredStats.Columns[e.ColumnIndex].Name;

                if (columnName == "colSelect")
                {
                    dgvDesiredStats.Rows[e.RowIndex].Cells["colSelect"].Value = false;
                }
                else if (columnName == "colQuantity")
                {
                    dgvDesiredStats.Rows[e.RowIndex].Cells["colQuantity"].Value = "1";
                }
            }

            UpdateSelectedCount();
        }

        private void dgvDesiredStats_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dgvDesiredStats.IsCurrentCellDirty)
                dgvDesiredStats.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvDesiredStats_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDesiredStats.CurrentCell == null)
                return;

            if (dgvDesiredStats.CurrentCell.ColumnIndex == dgvDesiredStats.Columns["colQuantity"].Index &&
                e.Control is ComboBox combo)
            {
                combo.BackColor = Color.FromArgb(30, 30, 30);
                combo.ForeColor = Color.White;
                combo.FlatStyle = FlatStyle.Flat;
            }
        }

        private void trackOpacity_Scroll(object sender, EventArgs e)
        {
            Opacity = trackOpacity.Value / 100.0;
        }

        private async void btnTestCapture_Click(object sender, EventArgs e)
        {
            try
            {
                btnTestCapture.Enabled = false;
                SetGeneralStatus("Executando teste completo...");

                var result = await CaptureAndAnalyzeAsync();

                List<string> detectedStats = result.detectedStats;
                List<DesiredStat> desiredStats = GetDesiredStats();

                UpdateMatchedStatsLabel(detectedStats, desiredStats);

                SetGeneralStatus($"Teste concluído - {detectedStats.Count} atributo(s) detectado(s).");
            }
            catch (Exception ex)
            {
                Show();
                Activate();

                SetGeneralStatus("Erro no teste.");

                string errorDetails = ex.InnerException?.ToString() ?? ex.ToString();

                MessageBox.Show(
                    $"Ocorreu um erro durante o teste:\n\n{errorDetails}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnTestCapture.Enabled = true;
            }
        }

        private async void btnCalibrateClick_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatusValue.Text = "Calibrando clique...";

                Rectangle captureRect = GetCaptureRectangle();

                MessageBox.Show(
                    "Após clicar em OK, o programa vai sumir por 3 segundos.\n\n" +
                    "Posicione o mouse exatamente sobre o botão 'Iniciar Horóscopo' do jogo.",
                    "Calibração do clique",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Hide();
                await Task.Delay(3000);

                Point mousePos = Cursor.Position;

                Show();
                Activate();

                _rollButtonOffset = new Point(
                    mousePos.X - captureRect.X,
                    mousePos.Y - captureRect.Y
                );

                _clickCalibrated = true;

                UpdateClickCalibrationInfo();
                lblStatusValue.Text = "Clique calibrado.";
            }
            catch (Exception ex)
            {
                Show();
                Activate();

                lblStatusValue.Text = "Erro na calibração.";
                MessageBox.Show(
                    $"Erro ao calibrar o clique:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ClickScreenPoint(Point point)
        {
            int screenWidth = Screen.PrimaryScreen!.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen!.Bounds.Height;

            int absoluteX = point.X * 65535 / (screenWidth - 1);
            int absoluteY = point.Y * 65535 / (screenHeight - 1);

            INPUT[] inputs = new INPUT[3];

            inputs[0] = new INPUT
            {
                type = INPUT_MOUSE,
                U = new InputUnion
                {
                    mi = new MOUSEINPUT
                    {
                        dx = absoluteX,
                        dy = absoluteY,
                        dwFlags = MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE
                    }
                }
            };

            inputs[1] = new INPUT
            {
                type = INPUT_MOUSE,
                U = new InputUnion
                {
                    mi = new MOUSEINPUT
                    {
                        dwFlags = MOUSEEVENTF_LEFTDOWN
                    }
                }
            };

            inputs[2] = new INPUT
            {
                type = INPUT_MOUSE,
                U = new InputUnion
                {
                    mi = new MOUSEINPUT
                    {
                        dwFlags = MOUSEEVENTF_LEFTUP
                    }
                }
            };

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        private async Task TestRollButtonClickAsync()
        {
            if (!_clickCalibrated)
            {
                MessageBox.Show("Calibre primeiro o clique do mouse.");
                return;
            }

            Point clickPoint = GetRollButtonScreenPoint();

            lblStatusValue.Text = "Testando clique...";

            Hide();
            await Task.Delay(300);

            ClickScreenPoint(clickPoint);

            await Task.Delay(300);

            Show();
            Activate();

            lblStatusValue.Text = "Teste de clique concluído.";
        }

        private async void btnTestMouseClick_Click(object sender, EventArgs e)
        {
            await TestRollButtonClickAsync();
        }

        private async Task RunAutomationAsync()
        {
            StartAutomationStatus();

            try
            {
                while (_isRolling)
                {
                    if (HasReachedAttemptLimit())
                    {
                        StopAutomationStatus("Limite atingido");
                        SetGeneralStatus("Limite de tentativas atingido.");
                        return;
                    }

                    // Primeira leitura do ciclo: captura normal
                    var result = await CaptureAndAnalyzeAsync(true);

                    if (!_isRolling)
                        return;

                    List<string> detectedStats = result.detectedStats;
                    List<DesiredStat> desiredStats = GetDesiredStats();

                    UpdateMatchedStatsLabel(detectedStats, desiredStats);

                    bool match = _statMatchService.Matches(detectedStats, desiredStats);

                    if (match)
                    {
                        StopAutomationStatus("Atributos encontrados");
                        SetGeneralStatus("Automação concluída com sucesso.");
                        return;
                    }

                    IncrementAttemptCount();

                    if (!_isRolling)
                        return;

                    Point clickPoint = GetRollButtonScreenPoint();

                    // Some, clica, espera a roletagem e já captura os novos atributos antes de voltar
                    Hide();
                    await Task.Delay(200);

                    if (!_isRolling)
                    {
                        Show();
                        Activate();
                        return;
                    }

                    ClickScreenPoint(clickPoint);
                    SetGeneralStatus("Aguardando roletagem...");

                    await Task.Delay(1500);

                    if (!_isRolling)
                    {
                        Show();
                        Activate();
                        return;
                    }

                    // Captura os novos atributos ainda oculto
                    result = await CaptureAndAnalyzeAsync(false);

                    if (!_isRolling)
                    {
                        Show();
                        Activate();
                        return;
                    }

                    detectedStats = result.detectedStats;
                    desiredStats = GetDesiredStats();

                    UpdateMatchedStatsLabel(detectedStats, desiredStats);

                    Show();
                    Activate();

                    bool matchAfterRoll = _statMatchService.Matches(detectedStats, desiredStats);

                    if (matchAfterRoll)
                    {
                        StopAutomationStatus("Atributos encontrados");
                        SetGeneralStatus("Automação concluída com sucesso.");
                        return;
                    }

                    int delaySeconds = (int)nudVisualDelay.Value;
                    await Task.Delay(delaySeconds * 1000);
                }
            }
            catch (Exception ex)
            {
                Show();
                Activate();

                StopAutomationStatus("Erro");

                MessageBox.Show(
                    $"Erro na automação:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void btnStartRolling_Click(object sender, EventArgs e)
        {
            if (!_clickCalibrated)
            {
                MessageBox.Show("Calibre primeiro o clique do mouse.");
                return;
            }

            List<DesiredStat> desiredStats = GetDesiredStats();

            if (desiredStats.Count == 0)
            {
                MessageBox.Show("Selecione pelo menos um atributo desejado.");
                return;
            }

            await RunAutomationAsync();
        }

        private void btnStopRolling_Click(object sender, EventArgs e)
        {
            _isRolling = false;
            StopAutomationStatus("Interrompido");
            Show();
            Activate();
            SetGeneralStatus("Automação interrompida pelo usuário.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _dragStart = e.Location;
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - _dragStart.X;
                Top += e.Y - _dragStart.Y;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            UnregisterHotKey(Handle, HOTKEY_ID_STOP);

            _elapsedTimer?.Stop();
            _elapsedTimer?.Dispose();
            picCapturedRegion.Image?.Dispose();

            base.OnFormClosed(e);
        }

        private (int matched, int required) GetMatchedDesiredStatsCount(List<string> detectedStats, List<DesiredStat> desiredStats)
        {
            if (detectedStats == null || desiredStats == null || desiredStats.Count == 0)
                return (0, 0);

            Dictionary<string, int> detectedCount = detectedStats
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());

            int matched = 0;
            int required = desiredStats.Sum(x => x.Quantity);

            foreach (DesiredStat desired in desiredStats)
            {
                detectedCount.TryGetValue(desired.Name, out int foundCount);
                matched += Math.Min(foundCount, desired.Quantity);
            }

            return (matched, required);
        }

        private void UpdateMatchedStatsLabel(List<string> detectedStats, List<DesiredStat> desiredStats)
        {
            var result = GetMatchedDesiredStatsCount(detectedStats, desiredStats);
            lblMatchedStatsValue.Text = $"{result.matched} / {result.required}";
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                string readmePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "README.txt"
                );

                if (!File.Exists(readmePath))
                {
                    MessageBox.Show(
                        "Arquivo README.txt não encontrado.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = readmePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao abrir README:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}