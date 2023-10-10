<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ventanas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top {
            height: 200px;
            object-fit: contain;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="row">
            <div class="col-1"></div>
            <div class="col-6">
                <div class="d-flex mt-3" role="search">
                    <input class="form-control me-2" type="search" placeholder="Buscar artículos" aria-label="Search">
                    <button class="btn btn-outline-success" type="submit">Buscar</button>
                </div>
            </div>
            <div class="col-1"></div>
            <div class="col-4">
                <div class="form-check mt-4">
                    <input class="form-check-input" type="checkbox" value="" id="inpFiltro" runat="server">
                    <label class="form-check-label" for="flexCheckDefault">Agregar filtros</label>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-1"></div>
            <div class="col-10 row row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater runat="server" ID="repRepetidor">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card">
                                <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text"><%#Eval("Descripcion") %></p>
                                    <h4 class="card-subtitle"><%#Eval("Precio") %></h4>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-1"></div>
        </div>
    </form>
</asp:Content>
