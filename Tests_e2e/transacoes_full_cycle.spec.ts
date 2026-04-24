import { test, expect } from "@playwright/test";

test("test", async ({ page }) => {
  await page.goto("http://localhost:5173/");
  await page
    .getByLabel("Main navigation")
    .getByRole("link", { name: "Transações" })
    .click();
  await page.getByRole("button", { name: "Adicionar Transação" }).click();
  await page.getByRole("textbox", { name: "Descrição" }).click();
  await page
    .getByRole("textbox", { name: "Descrição" })
    .fill("Pagamento Freelance teste");
  await page.getByRole("spinbutton", { name: "Valor" }).click();
  await page.getByRole("spinbutton", { name: "Valor" }).fill("2100");
  await page.getByRole("textbox", { name: "Data" }).fill("2026-01-22");
  await page.getByRole("button", { name: "Abrir lista" }).first().click();
  await page.getByRole("option", { name: "João Silva" }).click();
  await page.getByRole("textbox", { name: "Lista de categorias" }).click();
  await page.getByRole("option", { name: "Freelance" }).click();
  await page.getByRole("button", { name: "Salvar" }).click();
  await page.getByRole("button", { name: "Salvar" }).click();
  await page.getByRole("textbox", { name: "Lista de categorias" }).click();
  await page.getByRole("textbox", { name: "Lista de categorias" }).fill("");
  await page.getByRole("button", { name: "Salvar" }).click();
  await page.getByRole("spinbutton", { name: "Valor" }).click();
  await page.getByRole("spinbutton", { name: "Valor" }).fill("2");
  await page.getByRole("button", { name: "Salvar" }).click();
  await page.getByRole("button", { name: "Salvar" }).click();
  await page.getByRole("spinbutton", { name: "Valor" }).click();
  await page.getByRole("button", { name: "Salvar" }).click();
  await page.getByRole("button", { name: "Cancelar" }).click();
  await page
    .getByLabel("Main navigation")
    .getByRole("link", { name: "Categorias" })
    .click();
  await page.getByRole("cell", { name: "Despesa" }).first().click();
  await page.getByRole("button", { name: "Adicionar Categoria" }).click();
  await page.getByRole("textbox", { name: "Descrição" }).click();
  await page
    .getByRole("textbox", { name: "Descrição" })
    .fill("Gasto de viagens");
  await page.getByRole("button", { name: "Salvar" }).click();
  await page.getByRole("cell", { name: "123" }).click();
  await page.getByRole("button", { name: "Próximo" }).click();
  await page.getByRole("button", { name: "1" }).click();
  await page.getByRole("link", { name: "Home" }).click();
  await page.getByRole("link", { name: "Categorias" }).nth(1).click();
  await page
    .getByLabel("Main navigation")
    .getByRole("link", { name: "Relatórios" })
    .click();
  await page.getByRole("columnheader", { name: "Pessoa" }).click();
  await page.getByRole("cell", { name: "Pedro Oliveira" }).click();
  await page
    .getByText("DashboardTransaçõesCategoriasPessoasRelatórios")
    .click();
  await page
    .getByRole("complementary")
    .getByRole("link", { name: "Dashboard" })
    .click();
  await page.getByText("💰Saldo AtualR$").click();
  await page.getByText("R$").nth(1).click();
  await page.getByText("R$").nth(2).click();
  await page.getByText("Transporte: -R$").click();
  await page.getByRole("link", { name: "Categorias" }).nth(1).click();
  await page.locator("div").filter({ hasText: "Descriçã" }).nth(4).click();
});
