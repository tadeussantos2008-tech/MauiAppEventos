# MauiAppEventos — Agenda 15

Aplicativo de **Cadastro de Eventos** desenvolvido em .NET MAUI como atividade da Agenda 15 — Mostrando Dados Dinâmicos com BindingContext.

Curso Técnico em Desenvolvimento de Sistemas   
Centro Paula Souza — ETEC — GEEaD 2026  
Desenvolvedor: **Tadeu Souza Santos**

---

## Funcionalidades

- Cadastro completo de eventos com nome, local, datas, participantes e custo
- Cálculo automático de duração usando `DateTime` e `TimeSpan`
- Cálculo automático do custo total baseado em participantes × custo × dias
- Preview em tempo real do total e duração enquanto o usuário preenche
- Resumo completo na segunda tela usando `BindingContext` e `StringFormat`
- Navegação assíncrona com `async/await`

---

## Conceitos da Agenda 15 aplicados

| Conceito | Onde foi aplicado |
|---|---|
| **BindingContext** | Objeto `Evento` passado da `MainPage` para `ResumoEventoPage` |
| **StringFormat no XAML** | Formatação de datas (`{0:dd/MM/yyyy}`), moeda (`{0:F2}`) e texto |
| **DateTime** | Armazenamento e exibição das datas de início e término |
| **TimeSpan** | Cálculo da duração em dias (`DataTermino - DataInicio`) |
| **async / await** | Botão de cadastro e navegação entre páginas |
| **Model classe Evento** | Propriedades calculadas `DuracaoDias`, `CustoTotal`, `DuracaoFormatada` |

---

## Como o BindingContext funciona neste projeto

```csharp
// MainPage.xaml.cs — cria o objeto e define o BindingContext
Evento evento = new Evento { Nome = txt_nome.Text, ... };

await Navigation.PushAsync(new Views.ResumoEventoPage
{
    BindingContext = evento   // passa os dados para a próxima tela
});
```

```xml
<!-- ResumoEventoPage.xaml — exibe os dados com Binding + StringFormat -->
<Label Text="{Binding Nome}" />
<Label Text="{Binding DataInicio, StringFormat='{0:dd/MM/yyyy}'}" />
<Label Text="{Binding CustoTotal, StringFormat='R$ {0:F2}'}" />
<Label Text="{Binding DuracaoFormatada}" />
```

---

## Estrutura do projeto

```
MauiAppEventos/
├── Models/
│   └── Evento.cs                   # Model com DateTime, TimeSpan e propriedades calculadas
├── Views/
│   ├── ResumoEventoPage.xaml       # Tela de resumo com BindingContext e StringFormat
│   ├── ResumoEventoPage.xaml.cs
│   ├── SobrePage.xaml              # Tela Sobre personalizada
│   └── SobrePage.xaml.cs
├── MainPage.xaml                   # Tela de cadastro com preview em tempo real
├── MainPage.xaml.cs                # Lógica com async/await
├── AppShell.xaml
├── AppShell.xaml.cs
└── README.md
```

---

## Tecnologias

| Tecnologia | Versão |
|---|---|
| .NET MAUI | .NET 8.0 |
| C# | 12 |
| XAML | — |
| Visual Studio | 2022 |
