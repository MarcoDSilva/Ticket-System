@ModelType TicketSystem.Cliente
@Code
    ViewData("Title") = "EditarCliente"
End Code

<h2>Edição de cliente</h2>

<div class="form-group">
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="col-form-label">
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

            @Html.HiddenFor(Function(cli) cli.ID_cliente)

            <div class="form-group">
                <div class="col-md-12">
                    <p>
                        @Html.LabelFor(Function(cli) cli.nome, New With {.class = "form-check-label"})
                        @Html.EditorFor(Function(cli) cli.nome, New With {.HtmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(cli) cli.nome, "", New With {.class = "text-danger"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(cli) cli.contacto, New With {.class = "form-check-label"})
                        @Html.EditorFor(Function(cli) cli.contacto, New With {.HtmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(cli) cli.contacto, "", New With {.class = "text-danger"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(cli) cli.email, New With {.class = "form-check-label"})
                        @Html.EditorFor(Function(cli) cli.email, New With {.HtmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(cli) cli.email, "", New With {.class = "text-danger"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(cli) cli.empresa, New With {.class = "form-check-label"})
                        @Html.EditorFor(Function(cli) cli.empresa, New With {.HtmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(cli) cli.empresa, "", New With {.class = "text-danger"})
                    </p>
                    <p>
                        @Html.LabelFor(Function(cli) cli.ID_utilizador, New With {.class = "form-check-label"})
                        @Html.EditorFor(Function(cli) cli.ID_utilizador, New With {.HtmlAttributes = New With {.class = "form-control"}})
                        @Html.ValidationMessageFor(Function(cli) cli.ID_utilizador, "", New With {.class = "text-danger"})
                    </p>
                </div>
            </div>

        </div>

    End Using

</div>

