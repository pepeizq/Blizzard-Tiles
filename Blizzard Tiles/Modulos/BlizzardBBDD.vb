Imports Newtonsoft.Json

Module BlizzardBBDD

    Public Function IDs()

        Dim lista As New List(Of BlizzardJuego) From {
            New BlizzardJuego("call-of-duty-black-ops-4", "VIPR", "55970"),
            New BlizzardJuego("call-of-duty-black-ops-cold-war", "ZEUS", "73929"),
            New BlizzardJuego("call-of-duty-modern-warfare", "ODIN", "68930"),
            New BlizzardJuego("call-of-duty-warzone", "ODIN", "73295"),
            New BlizzardJuego("call-of-duty-modern-warfare-2-campaign-remastered", "LAZR", "73521"),
            New BlizzardJuego("diablo-iii", "D3", "51"),
            New BlizzardJuego("hearthstone-heroes-of-warcraft", "WTCG", "29509"),
            New BlizzardJuego("heroes-of-the-storm", "Hero", "29489"),
            New BlizzardJuego("overwatch", "Pro", "20991"),
            New BlizzardJuego("starcraft-remastered", "S1", "28298"),
            New BlizzardJuego("starcraft-ii", "S2", "33511"),
            New BlizzardJuego("warcraft-iii-reforged", "W3", "44414"),
            New BlizzardJuego("world-of-warcraft-shadowlands", "WoW", "61710")
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

    Public Slug As String
    Public IDEjecutable As String
    Public IDTienda As String

    Public Sub New(ByVal slug As String, ByVal idEjecutable As String, ByVal idTienda As String)
        Me.Slug = slug
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