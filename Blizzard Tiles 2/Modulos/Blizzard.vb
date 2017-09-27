Imports Microsoft.Toolkit.Uwp.UI.Controls
Imports Windows.Storage
Imports Windows.Storage.AccessCache
Imports Windows.Storage.Pickers
Imports Windows.UI

Module Blizzard

    Public Async Sub Generar(boolBuscarCarpeta As Boolean)

        Dim recursos As Resources.ResourceLoader = New Resources.ResourceLoader()

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Dim botonAñadirCarpetaTexto As TextBlock = pagina.FindName("botonAñadirCarpetaBlizzardTexto")

        Dim botonCarpetaTexto As TextBlock = pagina.FindName("tbBlizzardConfigCarpeta")

        Dim gv As GridView = pagina.FindName("gridViewTilesBlizzard")

        gv.Items.Clear()

        Dim carpeta As StorageFolder = Nothing

        Try
            If boolBuscarCarpeta = True Then
                Dim carpetapicker As FolderPicker = New FolderPicker()

                carpetapicker.FileTypeFilter.Add("*")
                carpetapicker.ViewMode = PickerViewMode.List

                carpeta = Await carpetapicker.PickSingleFolderAsync()
            Else
                carpeta = Await StorageApplicationPermissions.FutureAccessList.GetFolderAsync("BattlenetCarpeta")
            End If
        Catch ex As Exception

        End Try

        Dim listaJuegos As New List(Of Tile)

        If Not carpeta Is Nothing Then
            Dim carpetasJuegos As IReadOnlyList(Of StorageFolder) = Await carpeta.GetFoldersAsync()
            Dim detectadoBool As Boolean = False

            For Each carpetaJuego As StorageFolder In carpetasJuegos
                Dim ficheros As IReadOnlyList(Of StorageFile) = Await carpetaJuego.GetFilesAsync()

                For Each fichero As StorageFile In ficheros
                    Dim nombreFichero As String = fichero.DisplayName.ToLower

                    If nombreFichero = "destiny2" And fichero.FileType = ".exe" Then
                        detectadoBool = True
                    End If

                    If nombreFichero = "diablo iii" And fichero.FileType = ".exe" Then
                        detectadoBool = True
                    End If

                    If nombreFichero = "hearthstone" And fichero.FileType = ".exe" Then
                        detectadoBool = True
                    End If

                    If nombreFichero = "heroes of the storm" And fichero.FileType = ".exe" Then
                        detectadoBool = True
                    End If

                    If nombreFichero = "overwatch" And fichero.FileType = ".exe" Then
                        detectadoBool = True
                    End If

                    If nombreFichero = "starcraft" And fichero.FileType = ".exe" Then
                        detectadoBool = True
                    End If

                    If nombreFichero = "starcraft ii" And fichero.FileType = ".exe" Then
                        detectadoBool = True
                    End If

                    If nombreFichero = "sc2" And fichero.FileType = ".exe" Then
                        detectadoBool = True
                    End If

                    If nombreFichero = "wow" And fichero.FileType = ".exe" Then
                        detectadoBool = True
                    End If
                Next
            Next

            If detectadoBool = True Then
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("BattlenetCarpeta", carpeta)
                botonCarpetaTexto.Text = carpeta.Path
                botonAñadirCarpetaTexto.Text = recursos.GetString("Change")

                For Each carpetaJuego As StorageFolder In carpetasJuegos
                    Dim ficheros As IReadOnlyList(Of StorageFile) = Await carpetaJuego.GetFilesAsync()

                    For Each fichero As StorageFile In ficheros
                        Dim nombreFichero As String = fichero.DisplayName.ToLower

                        Dim ejecutable As String = Nothing
                        Dim imagenWide As String = Nothing
                        Dim imagenMedium As String = Nothing
                        Dim imagenSmall As String = Nothing

                        If nombreFichero = "destiny2" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://DST2"
                            imagenWide = "ms-appx:///Assets/Juegos/de2.png"
                            imagenMedium = "ms-appx:///Assets/Juegos/de2m.jpg"
                            imagenSmall = "ms-appx:///Assets/Juegos/de2s.jpg"
                        End If

                        If nombreFichero = "diablo iii" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://D3"
                            imagenWide = "ms-appx:///Assets/Juegos/di3.jpg"
                            imagenMedium = "ms-appx:///Assets/Juegos/di3m.jpg"
                            imagenSmall = "ms-appx:///Assets/Juegos/di3s.png"
                        End If

                        If nombreFichero = "hearthstone" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://WTCG"
                            imagenWide = "ms-appx:///Assets/Juegos/hea.jpg"
                            imagenMedium = "ms-appx:///Assets/Juegos/heam.jpg"
                            imagenSmall = "ms-appx:///Assets/Juegos/heas.png"
                        End If

                        If nombreFichero = "heroes of the storm" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://Hero"
                            imagenWide = "ms-appx:///Assets/Juegos/her.jpg"
                            imagenMedium = "ms-appx:///Assets/Juegos/herm.jpg"
                            imagenSmall = "ms-appx:///Assets/Juegos/hers.png"
                        End If

                        If nombreFichero = "overwatch" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://Pro"
                            imagenWide = "ms-appx:///Assets/Juegos/ove.png"
                            imagenMedium = "ms-appx:///Assets/Juegos/ovem.jpg"
                            imagenSmall = "ms-appx:///Assets/Juegos/oves.png"
                        End If

                        If nombreFichero = "starcraft" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://S1"
                            imagenWide = "ms-appx:///Assets/Juegos/sc1.jpg"
                            imagenMedium = "ms-appx:///Assets/Juegos/sc1m.jpg"
                            imagenSmall = "ms-appx:///Assets/Juegos/sc1s.png"
                        End If

                        If nombreFichero = "sc2" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://S2"
                            imagenWide = "ms-appx:///Assets/Juegos/sc2.jpg"
                            imagenMedium = "ms-appx:///Assets/Juegos/sc2m.jpg"
                            imagenSmall = "ms-appx:///Assets/Juegos/sc2s.png"
                        End If

                        If nombreFichero = "starcraft ii" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://S2"
                            imagenWide = "ms-appx:///Assets/Juegos/sc2.jpg"
                            imagenMedium = "ms-appx:///Assets/Juegos/sc2m.jpg"
                            imagenSmall = "ms-appx:///Assets/Juegos/sc2s.png"
                        End If

                        If nombreFichero = "wow" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://WoW"
                            imagenWide = "ms-appx:///Assets/Juegos/wow.jpg"
                            imagenMedium = "ms-appx:///Assets/Juegos/wowm.jpg"
                            imagenSmall = "ms-appx:///Assets/Juegos/wows.png"
                        End If

                        If Not ejecutable = Nothing Then
                            Dim titulo As String = carpetaJuego.Name

                            Dim tituloBool As Boolean = False
                            Dim i As Integer = 0
                            While i < listaJuegos.Count
                                If listaJuegos(i).Titulo = titulo Then
                                    tituloBool = True
                                End If
                                i += 1
                            End While

                            If tituloBool = False Then
                                Dim juego As New Tile(titulo, Nothing, New Uri(ejecutable), New Uri(imagenWide), New Uri(imagenMedium), New Uri(imagenSmall), "Blizzard App", Nothing)
                                listaJuegos.Add(juego)
                            End If
                        End If
                    Next
                Next
            End If
        End If

        Dim panelNoJuegos As DropShadowPanel = pagina.FindName("panelAvisoNoJuegos")
        Dim gridSeleccionar As Grid = pagina.FindName("gridSeleccionarJuego")

        If listaJuegos.Count > 0 Then
            panelNoJuegos.Visibility = Visibility.Collapsed
            gridSeleccionar.Visibility = Visibility.Visible

            gv.Visibility = Visibility.Visible

            listaJuegos.Sort(Function(x, y) x.Titulo.CompareTo(y.Titulo))

            gv.Items.Clear()

            For Each juego In listaJuegos
                Dim boton As New Button

                Dim imagen As New ImageEx

                Try
                    imagen.Source = New BitmapImage(juego.ImagenWide)
                Catch ex As Exception

                End Try

                imagen.IsCacheEnabled = True
                imagen.Stretch = Stretch.UniformToFill
                imagen.Padding = New Thickness(0, 0, 0, 0)

                boton.Tag = juego
                boton.Content = imagen
                boton.Padding = New Thickness(0, 0, 0, 0)
                boton.BorderThickness = New Thickness(1, 1, 1, 1)
                boton.BorderBrush = New SolidColorBrush(Colors.Black)
                boton.Background = New SolidColorBrush(Colors.Transparent)

                Dim tbToolTip As TextBlock = New TextBlock With {
                    .Text = juego.Titulo,
                    .FontSize = 16
                }

                ToolTipService.SetToolTip(boton, tbToolTip)
                ToolTipService.SetPlacement(boton, PlacementMode.Mouse)

                AddHandler boton.Click, AddressOf BotonTile_Click

                gv.Items.Add(boton)
            Next

            If boolBuscarCarpeta = True Then
                Toast(listaJuegos.Count.ToString + " " + recursos.GetString("GamesDetected"), Nothing)
            End If
        Else
            panelNoJuegos.Visibility = Visibility.Visible
            gridSeleccionar.Visibility = Visibility.Collapsed

            gv.Visibility = Visibility.Collapsed
        End If

    End Sub

    Private Sub BotonTile_Click(sender As Object, e As RoutedEventArgs)

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Dim gv As GridView = pagina.FindName("gridViewTilesBlizzard")

        Dim botonJuego As Button = e.OriginalSource

        Dim borde As Thickness = New Thickness(6, 6, 6, 6)
        If botonJuego.BorderThickness = borde Then
            botonJuego.BorderThickness = New Thickness(1, 1, 1, 1)
            botonJuego.BorderBrush = New SolidColorBrush(Colors.Black)

            Dim grid As Grid = pagina.FindName("gridAñadirTiles")
            grid.Visibility = Visibility.Collapsed

            Dim gridSeleccionar As Grid = pagina.FindName("gridSeleccionarJuego")
            gridSeleccionar.Visibility = Visibility.Visible
        Else
            For Each item In gv.Items
                Dim itemBoton As Button = item
                itemBoton.BorderThickness = New Thickness(1, 1, 1, 1)
                itemBoton.BorderBrush = New SolidColorBrush(Colors.Black)
            Next

            botonJuego.BorderThickness = New Thickness(6, 6, 6, 6)
            botonJuego.BorderBrush = New SolidColorBrush(App.Current.Resources("ColorSecundario"))

            Dim botonAñadirTile As Button = pagina.FindName("botonAñadirTile")
            Dim juego As Tile = botonJuego.Tag
            botonAñadirTile.Tag = juego

            Dim imageJuegoSeleccionado As ImageEx = pagina.FindName("imageJuegoSeleccionado")
            Dim imagenCapsula As String = juego.ImagenWide.ToString
            imageJuegoSeleccionado.Source = New BitmapImage(New Uri(imagenCapsula))

            Dim tbJuegoSeleccionado As TextBlock = pagina.FindName("tbJuegoSeleccionado")
            tbJuegoSeleccionado.Text = juego.Titulo

            Dim grid As Grid = pagina.FindName("gridAñadirTiles")
            grid.Visibility = Visibility.Visible

            Dim gridSeleccionar As Grid = pagina.FindName("gridSeleccionarJuego")
            gridSeleccionar.Visibility = Visibility.Collapsed
        End If

    End Sub

End Module
