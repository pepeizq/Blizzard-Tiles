Imports Newtonsoft.Json

Module BlizzardBBDD

    Public Function IDs()
        'Dim lista As New List(Of BlizzardBBDDEntrada) From {
        '    New BlizzardBBDDEntrada("Call of Duty: Black Ops 4", "VIPR", "call-of-duty", New List(Of String) From {"blackops4"}, "ms-appx:///Assets/Juegos/bo4s.png", "ms-appx:///Assets/Juegos/bo4m.jpg", "ms-appx:///Assets/Juegos/bo4.png"),
        '    New BlizzardBBDDEntrada("Call of Duty: Modern Warfare", "ODIN", "call-of-duty-mw", New List(Of String) From {"modernwarfare"}, "ms-appx:///Assets/Juegos/mws.png", "ms-appx:///Assets/Juegos/mwm.jpg", "ms-appx:///Assets/Juegos/mw.jpg"),
        '    New BlizzardBBDDEntrada("Call of Duty: Modern Warfare 2 Remastered", "LAZR", "call-of-duty-mw2cr", New List(Of String) From {"modernwarfare"}, "ms-appx:///Assets/Juegos/mw2s.png", "ms-appx:///Assets/Juegos/mw2m.jpg", "ms-appx:///Assets/Juegos/mw2.png"),
        '    New BlizzardBBDDEntrada("Diablo III", "D3", "diablo-iii", New List(Of String) From {"diablo iii", "diablo iii launcher"}, "ms-appx:///Assets/Juegos/di3s.png", "ms-appx:///Assets/Juegos/di3m.jpg", "ms-appx:///Assets/Juegos/di3.jpg"),
        '    New BlizzardBBDDEntrada("Hearthstone", "WTCG", "hearthstone", New List(Of String) From {"hearthstone"}, "ms-appx:///Assets/Juegos/heas.png", "ms-appx:///Assets/Juegos/heam.jpg", "ms-appx:///Assets/Juegos/hea.jpg"),
        '    New BlizzardBBDDEntrada("Heroes of the Storm", "Hero", "heroes-of-the-storm", New List(Of String) From {"heroes of the storm"}, "ms-appx:///Assets/Juegos/hers.png", "ms-appx:///Assets/Juegos/herm.jpg", "ms-appx:///Assets/Juegos/her.jpg"),
        '    New BlizzardBBDDEntrada("Overwatch", "Pro", "overwatch", New List(Of String) From {"overwatch", "overwatch launcher"}, "ms-appx:///Assets/Juegos/oves.png", "ms-appx:///Assets/Juegos/ovem.jpg", "ms-appx:///Assets/Juegos/ove.png"),
        '    New BlizzardBBDDEntrada("StarCraft", "S1", "starcraft-remastered", New List(Of String) From {"starcraft"}, "ms-appx:///Assets/Juegos/sc1s.png", "ms-appx:///Assets/Juegos/sc1m.jpg", "ms-appx:///Assets/Juegos/sc1.jpg"),
        '    New BlizzardBBDDEntrada("StarCraft II", "S2", "starcraft-ii", New List(Of String) From {"starcraft ii", "sc2"}, "ms-appx:///Assets/Juegos/sc2s.png", "ms-appx:///Assets/Juegos/sc2m.jpg", "ms-appx:///Assets/Juegos/sc2.jpg"),
        '    New BlizzardBBDDEntrada("Warcraft III: Reforged", "W3", "warcraft-iii", New List(Of String) From {"w3"}, "ms-appx:///Assets/Juegos/w3s.png", "ms-appx:///Assets/Juegos/w3m.jpg", "ms-appx:///Assets/Juegos/w3.jpg"),
        '    New BlizzardBBDDEntrada("World of Warcraft", "WoW", "world-of-warcraft", New List(Of String) From {"wow", "wow launcher"}, "ms-appx:///Assets/Juegos/wows.png", "ms-appx:///Assets/Juegos/wowm.jpg", "ms-appx:///Assets/Juegos/wow.jpg"),
        '    New BlizzardBBDDEntrada("World of Warcraft Classic", "wow_classic", "world-of-warcraft", New List(Of String) From {"wow", "wow launcher"}, "ms-appx:///Assets/Juegos/wows.png", "ms-appx:///Assets/Juegos/wowcm.jpg", "ms-appx:///Assets/Juegos/wowc.jpg")
        '}

        Dim lista As New List(Of BlizzardJuego) From {
            New BlizzardJuego("call-of-duty-black-ops-4", "VIPR", "55970", False),
            New BlizzardJuego("call-of-duty-modern-warfare", "ODIN", "68930", True),
            New BlizzardJuego("call-of-duty-warzone", "ODIN", "73295", True),
            New BlizzardJuego("call-of-duty-modern-warfare-2-campaign-remastered", "LAZR", "73521", True),
            New BlizzardJuego("diablo-iii", "D3", "51", True),
            New BlizzardJuego("hearthstone-heroes-of-warcraft", "WTCG", "29509", True),
            New BlizzardJuego("heroes-of-the-storm", "Hero", "29489", True),
            New BlizzardJuego("overwatch", "Pro", "20991", True),
            New BlizzardJuego("starcraft-remastered", "S1", "28298", True),
            New BlizzardJuego("starcraft-ii", "S2", "33511", True),
            New BlizzardJuego("warcraft-iii-reforged", "W3", "44414", True),
            New BlizzardJuego("world-of-warcraft-shadowlands", "WoW", "61710", True)
        }

        Return lista
    End Function

    Public Function Familias()

        Dim lista As New List(Of String) From {
            "world-of-warcraft",
            "overwatch",
            "diablo-iii",
            "hearthstone",
            "heroes-of-the-storm",
            "starcraft-ii",
            "starcraft-remastered",
            "call-of-duty-mw",
            "diablo-ii",
            "warcraft-iii",
            "call-of-duty",
            "call-of-duty-mw2cr"
        }

        Return lista
    End Function

End Module

Public Class BlizzardJuego

    Public Slug As String
    Public IDEjecutable As String
    Public IDTienda As String
    Public MostrarLogo As Boolean

    Public Sub New(ByVal slug As String, ByVal idEjecutable As String, ByVal idTienda As String, ByVal mostrarLogo As Boolean)
        Me.Slug = slug
        Me.IDEjecutable = idEjecutable
        Me.IDTienda = idTienda
        Me.MostrarLogo = mostrarLogo
    End Sub

End Class

Public Class BlizzardAPIFamilia

    <JsonProperty("browsingCards")>
    Public Fichas As List(Of BlizzardAPIFamiliaJuego)

End Class

Public Class BlizzardAPIFamiliaJuego

    <JsonProperty("title")>
    Public Titulo As String

    <JsonProperty("subTitle")>
    Public Subtitulo As String

    <JsonProperty("slug")>
    Public Slug As String

    <JsonProperty("productImageUrl")>
    Public Imagen As String

    <JsonProperty("verticalImageUrl")>
    Public ImagenVertical As String

    <JsonProperty("horizontalImageUrl")>
    Public ImagenHorizontal As String

    <JsonProperty("productIds")>
    Public IDs As List(Of Integer)

End Class

Public Class BlizzardAPIJuego

    <JsonProperty("logoUrl")>
    Public Icono As String

End Class