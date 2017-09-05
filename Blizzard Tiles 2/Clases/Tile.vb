Public Class Tile

    Public Property Titulo As String
    Public Property ID As String
    Public Property Enlace As Uri
    Public Property ImagenWide As Uri
    Public Property ImagenMedium As Uri
    Public Property ImagenSmall As Uri
    Public Property Cliente As String
    Public Property Tile As Tile

    Public Sub New(ByVal titulo As String, ByVal id As String, ByVal enlace As Uri,
                   ByVal imagenWide As Uri, ByVal imagenMedium As Uri, ByVal imagenSmall As Uri,
                   ByVal cliente As String, ByVal tile As Tile)
        Me.Titulo = titulo
        Me.ID = id
        Me.Enlace = enlace
        Me.ImagenWide = imagenWide
        Me.ImagenMedium = imagenMedium
        Me.ImagenSmall = imagenSmall
        Me.Cliente = cliente
        Me.Tile = tile
    End Sub
End Class
