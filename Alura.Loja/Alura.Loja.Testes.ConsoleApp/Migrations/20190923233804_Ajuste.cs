using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    public partial class Ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Promocao_ProdutoId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_PromocaoProduto_Produto_ProdutoId",
                table: "PromocaoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_PromocaoProduto_Promocao_PromocaoId",
                table: "PromocaoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promocao",
                table: "Promocao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.RenameTable(
                name: "Promocao",
                newName: "Promocoes");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promocoes",
                table: "Promocoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Promocoes_ProdutoId",
                table: "Compras",
                column: "ProdutoId",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromocaoProduto_Produtos_ProdutoId",
                table: "PromocaoProduto",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromocaoProduto_Promocoes_PromocaoId",
                table: "PromocaoProduto",
                column: "PromocaoId",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Promocoes_ProdutoId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_PromocaoProduto_Produtos_ProdutoId",
                table: "PromocaoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_PromocaoProduto_Promocoes_PromocaoId",
                table: "PromocaoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promocoes",
                table: "Promocoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Promocoes",
                newName: "Promocao");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promocao",
                table: "Promocao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Promocao_ProdutoId",
                table: "Compras",
                column: "ProdutoId",
                principalTable: "Promocao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromocaoProduto_Produto_ProdutoId",
                table: "PromocaoProduto",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromocaoProduto_Promocao_PromocaoId",
                table: "PromocaoProduto",
                column: "PromocaoId",
                principalTable: "Promocao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
