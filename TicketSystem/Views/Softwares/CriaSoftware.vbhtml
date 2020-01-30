@ModelType TicketSystem.Software
@Code
    ViewData("Title") = "CriaSoftware"
End Code

<h2>Adição novo software</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<div class="form-horizontal">
         <div class="form-group">
             <p>
                 @Html.LabelFor(Function(modelSoft) modelSoft.nome)
                 @Html.TextBoxFor(Function(modelSoft) modelSoft.nome)
             </p>
         </div>
        <input type="submit" name="submit" value="Inserir" class="btn btn-primary" />
        <button type="button" class="btn btn-default" onclick="location.href='@Url.Action("Index", "Softwares")'">
            Voltar
        </button>
    </div>
End Using

