<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Proyectos.aspx.cs" Inherits="AspArquitectura.Proyectos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Mi ASP Proyectos</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12" style="margin: auto;">
                        <asp:GridView runat="server" ID="gvProyectos" CssClass="table table-hover table-dark"></asp:GridView>
                        <asp:DropDownList runat="server" ID="ddlProyectos" Style="margin: 10px;" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlProyectos_SelectedIndexChanged" >
                        <asp:ListItem Text="[Proyecto a editar]" Value="" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                <label>Nombre de proyecto</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="txtNombre" aria-describedby="Nombre" placeholder="Ingresa nombre de proyecto" required></asp:TextBox>
                <small id="Nombre" class="form-text text-muted">Proyecto</small>
            </div>
                </div>
                <div class="col">
                    <div class="form-group">
                <label>Costo del proyecto</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="txtCosto" placeholder="$$$" required></asp:TextBox>
            </div>
                </div>
                <div class="col">
                    <div class="form-group">
                <label>Fecha</label>
                <asp:TextBox runat="server" type="Date" class="form-control" id="txtDate" required></asp:TextBox>
             </div>
                </div>
            </div>
            <div class="form-group">
                <label ">Descripción de proyecto</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="txtDescripcion" placeholder="Describe el proyecto" required></asp:TextBox>
            </div>
            <div class ="form-group">
                <asp:FileUpload ID="FU" class="form-control" runat="server" />
                <asp:Label ID="txtImg" runat="server" Text=""></asp:Label>
            </div>
            <asp:Button id="BtnGuardar" CssClass="btn btn-outline-success align-content-xl-between" runat="server" Text="Guardar" OnClick="BtnGuardar_Click"></asp:Button>
            <asp:Button ID="BtnDelete" CssClass="btn btn-outline-success align-content-xl-between"  runat="server" Text="Eliminar" Visible="False" OnClick="BtnDelete_Click"></asp:Button>
            <asp:HiddenField ID="txtId" runat="server" > </asp:HiddenField>
            <br />
            <br />
            <br />
            <br />
        </form>
    </div>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</body>
</html>
