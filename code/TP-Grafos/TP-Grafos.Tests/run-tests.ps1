# Script para executar testes e gerar relatório de cobertura
# Testes Unitários - TP Grafos

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  Testes Unitários - TP Grafos" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Compila o projeto principal
Write-Host "1. Compilando projeto principal..." -ForegroundColor Yellow
Set-Location "..\TP-Grafos"
dotnet build TP-Grafos.sln
if ($LASTEXITCODE -ne 0) {
    Write-Host "Erro na compilação do projeto principal!" -ForegroundColor Red
    exit 1
}
Write-Host "✓ Projeto principal compilado com sucesso!" -ForegroundColor Green
Write-Host ""

# Compila os testes
Write-Host "2. Compilando testes..." -ForegroundColor Yellow
Set-Location "..\TP-Grafos.Tests"
dotnet build
if ($LASTEXITCODE -ne 0) {
    Write-Host "Erro na compilação dos testes!" -ForegroundColor Red
    exit 1
}
Write-Host "✓ Testes compilados com sucesso!" -ForegroundColor Green
Write-Host ""

# Executa os testes com cobertura
Write-Host "3. Executando testes com cobertura de código..." -ForegroundColor Yellow
dotnet test --collect:"XPlat Code Coverage"
if ($LASTEXITCODE -ne 0) {
    Write-Host "Alguns testes falharam!" -ForegroundColor Red
} else {
    Write-Host "✓ Todos os testes passaram!" -ForegroundColor Green
}
Write-Host ""

# Gera relatório HTML
Write-Host "4. Gerando relatório HTML de cobertura..." -ForegroundColor Yellow
reportgenerator "-reports:TestResults\**\coverage.cobertura.xml" "-targetdir:TestResults\CoverageReport" -reporttypes:Html
if ($LASTEXITCODE -ne 0) {
    Write-Host "Erro ao gerar relatório!" -ForegroundColor Red
    exit 1
}
Write-Host "✓ Relatório gerado com sucesso!" -ForegroundColor Green
Write-Host ""

# Exibe localização do relatório
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Relatório disponível em:" -ForegroundColor Cyan
Write-Host "$(Get-Location)\TestResults\CoverageReport\index.html" -ForegroundColor White
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Pergunta se deseja abrir o relatório
$resposta = Read-Host "Deseja abrir o relatório no navegador? (S/N)"
if ($resposta -eq "S" -or $resposta -eq "s") {
    Start-Process "TestResults\CoverageReport\index.html"
}

Write-Host ""
Write-Host "Concluído!" -ForegroundColor Green
