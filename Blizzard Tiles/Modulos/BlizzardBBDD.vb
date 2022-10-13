Imports Newtonsoft.Json

Module BlizzardBBDD

    Public Function IDs()

        Dim lista As New List(Of BlizzardJuego) From {
            New BlizzardJuego("Blizzard Arcade Collection", "RTRO", "142345"),
            New BlizzardJuego("Call of Duty: Black Ops 4", "VIPR", "55970"),
            New BlizzardJuego("Call of Duty: Black Ops Cold War", "ZEUS", "73929"),
            New BlizzardJuego("Call of Duty: Modern Warfare", "ODIN", "68930"),
            New BlizzardJuego("Call of Duty: Modern Warfare 2 Campaign Remastered", "LAZR", "73521"),
            New BlizzardJuego("Call of Duty: Modern Warfare II", "AUKS", "788220"),
            New BlizzardJuego("Call of Duty: Vanguard", "FORE", "166236"),
            New BlizzardJuego("Call of Duty: Warzone", "ODIN", "73295"),
            New BlizzardJuego("Crash Bandicoot 4: It’s About Time", "WLBY", "165996"),
            New BlizzardJuego("Diablo II: Resurrected", "OSI", "168304"),
            New BlizzardJuego("Diablo III", "D3", "51"),
            New BlizzardJuego("Diablo Immortal", "ANBS", "27472"),
            New BlizzardJuego("Hearthstone", "WTCG", "29509"),
            New BlizzardJuego("Heroes of the Storm", "Hero", "29489"),
            New BlizzardJuego("Overwatch 2", "Pro", "20991"),
            New BlizzardJuego("StarCraft II", "S2", "33511"),
            New BlizzardJuego("StarCraft Remastered", "S1", "28298"),
            New BlizzardJuego("Warcraft III: Reforged", "W3", "44414"),
            New BlizzardJuego("World of Warcraft", "WoW", "61710")
        }

        Return lista
    End Function

End Module

Public Class BlizzardJuego

    Public Titulo As String
    Public IDEjecutable As String
    Public IDTienda As String

    Public Sub New(titulo As String, idEjecutable As String, idTienda As String)
        Me.Titulo = titulo
        Me.IDEjecutable = idEjecutable
        Me.IDTienda = idTienda
    End Sub

End Class