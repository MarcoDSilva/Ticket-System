Public Class Conector

    'separamos o ficheiro da string conection para proteção e ficando assim uma melhor maneira de poder
    'alterar a string connection caso seja necessário

    Public Shared ReadOnly stringConnection = "Data Source=DESKTOP-L69QEGS\SQLEXPRESS;
                            Initial Catalog=TicketSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;
                            TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

End Class
