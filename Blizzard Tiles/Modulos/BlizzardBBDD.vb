Imports Newtonsoft.Json

Module BlizzardBBDD

    Public Function IDs()

        Dim lista As New List(Of BlizzardJuego) From {
            New BlizzardJuego("Blizzard Arcade Collection", "RTRO", "142345"),
            New BlizzardJuego("Call of Duty: Black Ops 4", "VIPR", "55970"),
            New BlizzardJuego("Call of Duty: Black Ops Cold War", "ZEUS", "73929"),
            New BlizzardJuego("Call of Duty: Modern Warfare", "ODIN", "68930"),
            New BlizzardJuego("Call of Duty: Modern Warfare 2 Campaign Remastered", "LAZR", "73521"),
            New BlizzardJuego("Call of Duty: Warzone", "ODIN", "73295"),
            New BlizzardJuego("Crash Bandicoot 4: It’s About Time", "WLBY", "165996"),
            New BlizzardJuego("Diablo III", "D3", "51"),
            New BlizzardJuego("Hearthstone", "WTCG", "29509"),
            New BlizzardJuego("Heroes of the Storm", "Hero", "29489"),
            New BlizzardJuego("Overwatch", "Pro", "20991"),
            New BlizzardJuego("StarCraft II", "S2", "33511"),
            New BlizzardJuego("StarCraft Remastered", "S1", "28298"),
            New BlizzardJuego("Warcraft III: Reforged", "W3", "44414"),
            New BlizzardJuego("World of Warcraft", "WoW", "61710")
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
            "call-of-duty-mw2cr",
            "call-of-duty-black-ops-cold-war"
        }

        Return lista
    End Function

End Module

Public Class BlizzardJuego

    Public Titulo As String
    Public IDEjecutable As String
    Public IDTienda As String

    Public Sub New(ByVal titulo As String, ByVal idEjecutable As String, ByVal idTienda As String)
        Me.Titulo = titulo
        Me.IDEjecutable = idEjecutable
        Me.IDTienda = idTienda
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