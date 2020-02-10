@Code
    ViewData("Title") = "Home Page"
End Code


<h2>Login</h2>
<div class="container-fluid">

    @If IsNothing(Session("login")) Then
        @<div class="form-group">
            <div class="col-form-label">Email: </div> <br />
            <input type="text" class="form-control" size="10" />
            <div class="col-form-label">Password:</div>    <br />
            <input type="password" class="form-control" size="10" />
            <input type="submit" class="btn btn-secondary" value="login" />
            <button type="button" class="btn btn-primary">Criar Conta</button>
            <button type="button" class="btn btn-warning">Recuperar Password</button>
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

            If Session("key").Equals(1) Then
                @<p>O seu cargo é administrador!</p>
            Else
                @<p>O seu cargo é técnico ou utilizador</p>
            End If
        End If
    End If
</div>


