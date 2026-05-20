# Senior QA Automation Engineer Challenge

Automated solution for the Senior QA Automation Engineer challenge using Playwright and C#.

## Objective

This test performs a combined UI and API validation:

1. Opens `https://demoqa.com/text-box`
2. Fills the form with the required values
3. Submits the form
4. Validates that the output section displays the submitted values correctly
5. Sends a GET request to `https://jsonplaceholder.typicode.com/posts/1`
6. Validates that:
   * The response status is `200`
   * The JSON contains `userId`, `id`, `title`, and `body`
   * The `id` field equals `1`
7. Prints exactly `All tests passed.` when every validation passes

## Tech Stack

* Playwright .NET
* C#
* NUnit
* .NET 8

## Prerequisites

Install the .NET 8 SDK before running the project.

## Install Dependencies

```bash
dotnet restore
```

## Install Playwright Browsers

```bash
pwsh bin/Debug/net8.0/playwright.ps1 install
```

If you are using bash or zsh:

```bash
./bin/Debug/net8.0/playwright.sh install
```

## Run the Test

```bash
dotnet test
```

## Run in Headed Mode

```bash
HEADED=1 dotnet test
```
