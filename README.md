# Astrolabio Recaster

Ferramenta desktop em C# / WinForms para leitura automática dos atributos do sistema de Astrolábio no Perfect World, com OCR, comparação de atributos desejados e automação de roletagem.

## Autor
Nathan Corrêa

## Funcionalidades
- Captura automática da área dos atributos
- OCR com Tesseract
- Parser tolerante a erros de leitura
- Seleção de atributos desejados
- Comparação automática com o resultado detectado
- Automação de roletagem com clique calibrado
- Interface com preview, status, tentativas e tempo

## Tecnologias
- C#
- .NET 8
- WinForms
- Tesseract OCR

## Estrutura
- `Astrolabio Recaster.cs` — interface principal e lógica da automação
- `Services/` — captura, OCR, parser e comparação
- `tessdata/` — dados do Tesseract

## Aviso legal
© 2026 Nathan Corrêa. Todos os direitos reservados.

Este repositório não concede permissão de uso, cópia, modificação ou redistribuição sem autorização prévia por escrito.