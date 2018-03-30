Imports Microsoft.Toolkit.Uwp.UI.Controls
Imports Windows.Storage
Imports Windows.Storage.AccessCache
Imports Windows.Storage.Pickers
Imports Windows.UI
Imports Windows.UI.Core
Imports Windows.UI.Xaml.Media.Animation

Module Blizzard

    Public Async Sub Generar(boolBuscarCarpeta As Boolean)

        Dim recursos As New Resources.ResourceLoader()

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Dim botonAñadirCarpetaTexto As TextBlock = pagina.FindName("botonAñadirCarpetaBlizzardTexto")

        Dim botonCarpetaTexto As TextBlock = pagina.FindName("tbBlizzardConfigCarpeta")

        Dim gv As GridView = pagina.FindName("gridViewTilesBlizzard")

        gv.Items.Clear()

        Dim carpeta As StorageFolder = Nothing

        Try
            If boolBuscarCarpeta = True Then
                Dim carpetapicker As New FolderPicker()

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
                        Dim clave As String = Nothing

                        Dim imagenPequeña As String = Nothing
                        Dim imagenMediana As String = Nothing
                        Dim imagenAncha As String = Nothing

                        If nombreFichero = "destiny2" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://DST2"
                            clave = "DST2"

                            imagenPequeña = "ms-appx:///Assets/Juegos/de2s.jpg"
                            imagenMediana = "ms-appx:///Assets/Juegos/de2m.jpg"
                            imagenAncha = "ms-appx:///Assets/Juegos/de2.png"
                        End If

                        If nombreFichero = "diablo iii" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://D3"
                            clave = "D3"

                            imagenPequeña = "ms-appx:///Assets/Juegos/di3s.png"
                            imagenMediana = "ms-appx:///Assets/Juegos/di3m.jpg"
                            imagenAncha = "ms-appx:///Assets/Juegos/di3.jpg"
                        End If

                        If nombreFichero = "hearthstone" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://WTCG"
                            clave = "WTCG"

                            imagenPequeña = "ms-appx:///Assets/Juegos/heas.png"
                            imagenMediana = "ms-appx:///Assets/Juegos/heam.jpg"
                            imagenAncha = "ms-appx:///Assets/Juegos/hea.jpg"
                        End If

                        If nombreFichero = "heroes of the storm" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://Hero"
                            clave = "Hero"

                            imagenPequeña = "ms-appx:///Assets/Juegos/hers.png"
                            imagenMediana = "ms-appx:///Assets/Juegos/herm.jpg"
                            imagenAncha = "ms-appx:///Assets/Juegos/her.jpg"
                        End If

                        If nombreFichero = "overwatch" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://Pro"
                            clave = "Pro"

                            imagenPequeña = "ms-appx:///Assets/Juegos/oves.png"
                            imagenMediana = "ms-appx:///Assets/Juegos/ovem.jpg"
                            imagenAncha = "ms-appx:///Assets/Juegos/ove.png"
                        End If

                        If nombreFichero = "starcraft" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://S1"
                            clave = "S1"

                            imagenPequeña = "ms-appx:///Assets/Juegos/sc1s.png"
                            imagenMediana = "ms-appx:///Assets/Juegos/sc1m.jpg"
                            imagenAncha = "ms-appx:///Assets/Juegos/sc1.jpg"
                        End If

                        If nombreFichero = "sc2" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://S2"
                            clave = "S2"

                            imagenPequeña = "ms-appx:///Assets/Juegos/sc2s.png"
                            imagenMediana = "ms-appx:///Assets/Juegos/sc2m.jpg"
                            imagenAncha = "ms-appx:///Assets/Juegos/sc2.jpg"
                        End If

                        If nombreFichero = "starcraft ii" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://S2"
                            clave = "S2"

                            imagenPequeña = "ms-appx:///Assets/Juegos/sc2s.png"
                            imagenMediana = "ms-appx:///Assets/Juegos/sc2m.jpg"
                            imagenAncha = "ms-appx:///Assets/Juegos/sc2.jpg"
                        End If

                        If nombreFichero = "wow" And fichero.FileType = ".exe" Then
                            ejecutable = "battlenet://WoW"
                            clave = "WoW"

                            imagenPequeña = "ms-appx:///Assets/Juegos/wows.png"
                            imagenMediana = "ms-appx:///Assets/Juegos/wowm.jpg"
                            imagenAncha = "ms-appx:///Assets/Juegos/wow.jpg"
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
                                Dim juego As New Tile(titulo, clave, New Uri(ejecutable), New Uri(imagenPequeña), New Uri(imagenMediana), New Uri(imagenAncha), New Uri(imagenMediana))
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
                    imagen.Source = New BitmapImage(juego.ImagenMediana)
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
                AddHandler boton.PointerEntered, AddressOf UsuarioEntraBoton
                AddHandler boton.PointerExited, AddressOf UsuarioSaleBoton

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

        Dim botonJuego As Button = e.OriginalSource
        Dim juego As Tile = botonJuego.Tag

        Dim botonAñadirTile As Button = pagina.FindName("botonAñadirTile")
        botonAñadirTile.Tag = juego

        Dim imagenJuegoSeleccionado As ImageEx = pagina.FindName("imagenJuegoSeleccionado")
        imagenJuegoSeleccionado.Source = New BitmapImage(juego.ImagenMediana)

        Dim tbJuegoSeleccionado As TextBlock = pagina.FindName("tbJuegoSeleccionado")
        tbJuegoSeleccionado.Text = juego.Titulo

        Dim gridAñadir As Grid = pagina.FindName("gridAñadirTile")
        gridAñadir.Visibility = Visibility.Visible

        ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("tile", botonJuego)

        Dim animacion As ConnectedAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("tile")

        If Not animacion Is Nothing Then
            animacion.TryStart(gridAñadir)
        End If

        Dim tbTitulo As TextBlock = pagina.FindName("tbTitulo")
        tbTitulo.Text = Package.Current.DisplayName + " (" + Package.Current.Id.Version.Major.ToString + "." + Package.Current.Id.Version.Minor.ToString + "." + Package.Current.Id.Version.Build.ToString + "." + Package.Current.Id.Version.Revision.ToString + ") - " + juego.Titulo

        '---------------------------------------------

        Dim imagenPequeña As ImageEx = pagina.FindName("imagenTilePequeña")
        imagenPequeña.Source = juego.ImagenPequeña
        imagenPequeña.Visibility = Visibility.Visible

        Dim tbPequeña As TextBlock = pagina.FindName("tbTilePequeña")
        tbPequeña.Visibility = Visibility.Collapsed

        '---------------------------------------------

        Dim imagenMediana As ImageEx = pagina.FindName("imagenTileMediana")
        imagenMediana.Source = juego.ImagenMediana
        imagenMediana.Visibility = Visibility.Visible

        Dim tbMediana As TextBlock = pagina.FindName("tbTileMediana")
        tbMediana.Visibility = Visibility.Collapsed

        '---------------------------------------------

        Dim imagenAncha As ImageEx = pagina.FindName("imagenTileAncha")
        imagenAncha.Source = juego.ImagenAncha
        imagenAncha.Visibility = Visibility.Visible

        Dim tbAncha As TextBlock = pagina.FindName("tbTileAncha")
        tbAncha.Visibility = Visibility.Collapsed

        '---------------------------------------------

        Dim imagenGrande As ImageEx = pagina.FindName("imagenTileGrande")
        imagenGrande.Source = juego.ImagenGrande
        imagenGrande.Visibility = Visibility.Visible

        Dim tbGrande As TextBlock = pagina.FindName("tbTileGrande")
        tbGrande.Visibility = Visibility.Collapsed

    End Sub

    Private Sub UsuarioEntraBoton(sender As Object, e As PointerRoutedEventArgs)

        Window.Current.CoreWindow.PointerCursor = New CoreCursor(CoreCursorType.Hand, 1)

    End Sub

    Private Sub UsuarioSaleBoton(sender As Object, e As PointerRoutedEventArgs)

        Window.Current.CoreWindow.PointerCursor = New CoreCursor(CoreCursorType.Arrow, 1)

    End Sub

End Module
