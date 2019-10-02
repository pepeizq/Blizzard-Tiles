Module BlizzardBBDD

    Public Function Listado()
        Dim lista As New List(Of BlizzardBBDDEntrada) From {
            New BlizzardBBDDEntrada("Call of Duty: Black Ops 4", "VIPR", New List(Of String) From {"blackops4"}, "ms-appx:///Assets/Juegos/bo4s.png", "ms-appx:///Assets/Juegos/bo4m.jpg", "ms-appx:///Assets/Juegos/bo4.png"),
            New BlizzardBBDDEntrada("Call of Duty: Modern Warfare", "ODIN", New List(Of String) From {"modernwarfare"}, "ms-appx:///Assets/Juegos/mws.png", "ms-appx:///Assets/Juegos/mwm.jpg", "ms-appx:///Assets/Juegos/mw.jpg"),
            New BlizzardBBDDEntrada("Diablo III", "D3", New List(Of String) From {"diablo iii", "diablo iii launcher"}, "ms-appx:///Assets/Juegos/di3s.png", "ms-appx:///Assets/Juegos/di3m.jpg", "ms-appx:///Assets/Juegos/di3.jpg"),
            New BlizzardBBDDEntrada("Hearthstone", "WTCG", New List(Of String) From {"hearthstone"}, "ms-appx:///Assets/Juegos/heas.png", "ms-appx:///Assets/Juegos/heam.jpg", "ms-appx:///Assets/Juegos/hea.jpg"),
            New BlizzardBBDDEntrada("Heroes of the Storm", "Hero", New List(Of String) From {"heroes of the storm"}, "ms-appx:///Assets/Juegos/hers.png", "ms-appx:///Assets/Juegos/herm.jpg", "ms-appx:///Assets/Juegos/her.jpg"),
            New BlizzardBBDDEntrada("Overwatch", "Pro", New List(Of String) From {"overwatch", "overwatch launcher"}, "ms-appx:///Assets/Juegos/oves.png", "ms-appx:///Assets/Juegos/ovem.jpg", "ms-appx:///Assets/Juegos/ove.png"),
            New BlizzardBBDDEntrada("StarCraft", "S1", New List(Of String) From {"starcraft"}, "ms-appx:///Assets/Juegos/sc1s.png", "ms-appx:///Assets/Juegos/sc1m.jpg", "ms-appx:///Assets/Juegos/sc1.jpg"),
            New BlizzardBBDDEntrada("StarCraft II", "S2", New List(Of String) From {"starcraft ii", "sc2"}, "ms-appx:///Assets/Juegos/sc2s.png", "ms-appx:///Assets/Juegos/sc2m.jpg", "ms-appx:///Assets/Juegos/sc2.jpg"),
            New BlizzardBBDDEntrada("World of Warcraft", "WoW", New List(Of String) From {"wow", "wow launcher"}, "ms-appx:///Assets/Juegos/wows.png", "ms-appx:///Assets/Juegos/wowm.jpg", "ms-appx:///Assets/Juegos/wow.jpg")
        }

        Return lista
    End Function

End Module

Public Class BlizzardBBDDEntrada

    Public Titulo As String
    Public ID As String
    Public Ejecutables As List(Of String)
    Public ImagenPequeña As String
    Public ImagenMediana As String
    Public ImagenAncha As String

    Public Sub New(ByVal titulo As String, ByVal id As String, ByVal ejecutables As List(Of String),
                   ByVal imagenPequeña As String, ByVal imagenMediana As String, ByVal imagenAncha As String)
        Me.Titulo = titulo
        Me.ID = id
        Me.Ejecutables = ejecutables
        Me.ImagenPequeña = imagenPequeña
        Me.ImagenMediana = imagenMediana
        Me.ImagenAncha = imagenAncha
    End Sub

End Class