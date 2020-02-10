@Code
    ViewData("Title") = "Index"
End Code

<h2>Logins</h2>



@If IsNothing(Session("login")) Then
    @<div class="form-group">
        <div class="col-form-label">Email: </div> <br />
        <input type="text" class="form-control" size="10" />
        <div class="col-form-label">Password:</div>    <br />
        <input type="password" class="form-control" size="10" />
        <input type="submit" class="btn btn-secondary" value="login" />
    </div>
Else
    If Session("login").Equals("ERRO") Then
        @<div class="form-group">
            <div class="col-form-label">Email: </div> <br />
            <input type="text" class="form-control" size="10" />
            <div class="col-form-label">Password:</div>    <br />
            <input type="password" class="form-control" size="10" />
            <input type="submit" class="btn btn-secondary" value="login" />
            <label class="text-danger">Password ou utilizador errado</label>
        </div>
    Else
        @<p>Sessão tem valor e é @Session("login").ToString()</p>
    End If
End If




@*@If Session("valor").Equals("sem valor") Then
        @<p>Sessão teste activa</p>
    Else
        @<p>Não encontrado</p>
    End If*@
