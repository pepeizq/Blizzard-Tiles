Imports Blizzard_Tiles.Configuracion
Imports Microsoft.Toolkit.Uwp.Helpers
Imports Microsoft.Toolkit.Uwp.UI.Animations
Imports Microsoft.Toolkit.Uwp.UI.Controls
Imports Windows.Storage
Imports Windows.Storage.FileProperties
Imports Windows.UI
Imports Windows.UI.Core
Imports Windows.UI.Xaml.Media.Animation

Module Blizzard

    Public anchoColumna As Integer = 180

    Public Async Sub Generar()

        Dim helper As New LocalObjectStorageHelper

        Dim recursos As New Resources.ResourceLoader()

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Dim gridProgreso As Grid = pagina.FindName("gridProgreso")
        Interfaz.Pestañas.Visibilidad(gridProgreso, Nothing, Nothing)

        Dim pbProgreso As ProgressBar = pagina.FindName("pbProgreso")
        pbProgreso.Value = 0

        Dim tbProgreso As TextBlock = pagina.FindName("tbProgreso")
        tbProgreso.Text = String.Empty

        Cache.Estado(False)
        LimpiezaArchivos.Estado(False)

        Dim gv As AdaptiveGridView = pagina.FindName("gvTiles")
        gv.DesiredWidth = anchoColumna
        gv.Items.Clear()

        Dim listaJuegos As New List(Of Tile)
        Dim carpetaFicheros As StorageFolder = Nothing
        Dim errorCarpeta As Boolean = False

        Try
            carpetaFicheros = Await StorageFolder.GetFolderFromPathAsync(ApplicationData.Current.LocalFolder.Path + "\Juegos")
        Catch ex As Exception
            errorCarpeta = True
        End Try

        If errorCarpeta = True Then
            Try
                Await ApplicationData.Current.LocalFolder.CreateFolderAsync("Juegos", CreationCollisionOption.ReplaceExisting)
                carpetaFicheros = Await StorageFolder.GetFolderFromPathAsync(ApplicationData.Current.LocalFolder.Path + "\Juegos")
            Catch ex As Exception

            End Try
        End If

        If Not carpetaFicheros Is Nothing Then
            Dim listaFicheros As IReadOnlyList(Of IStorageItem) = Await carpetaFicheros.GetFilesAsync

            If Not listaFicheros Is Nothing Then
                If listaFicheros.Count > 0 Then
                    For Each fichero In listaFicheros
                        Dim propiedades As BasicProperties = Await fichero.GetBasicPropertiesAsync

                        If propiedades.Size > 0 Then
                            If fichero.Name.Contains("juego_") Then
                                Dim temp As Tile = Await helper.ReadFileAsync(Of Tile)("Juegos\" + fichero.Name)
                                listaJuegos.Add(temp)
                            End If
                        End If
                    Next
                End If
            End If
        End If

        If listaJuegos Is Nothing Then
            listaJuegos = New List(Of Tile)
        End If

        Dim juegosBBDD As List(Of BlizzardJuego) = BlizzardBBDD.IDs

        For Each juegoBBDD In juegosBBDD
            Dim añadir As Boolean = True

            Dim i As Integer = 0
            If Not listaJuegos Is Nothing Then
                While i < listaJuegos.Count
                    If listaJuegos(i).ID = juegoBBDD.IDTienda Then
                        añadir = False
                    End If
                    i += 1
                End While
            End If

            If añadir = True Then
                Dim titulo As String = juegoBBDD.Titulo

                Dim imagenIcono As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDTienda, "icono")
                Dim imagenLogo As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDTienda, "logo")
                Dim imagenAncha As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDTienda, "ancha")
                Dim imagenGrande As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDTienda, "grande")

                Dim juego As New Tile(titulo, juegoBBDD.IDTienda, "battlenet://" + juegoBBDD.IDEjecutable, imagenIcono, imagenLogo, imagenAncha, imagenGrande)
                listaJuegos.Add(juego)
            End If
        Next

        Dim resultadosBusqueda As New List(Of Interfaz.BusquedaFichero)

        If Not listaJuegos Is Nothing Then
            If listaJuegos.Count > 0 Then
                For Each juego In listaJuegos
                    If Not juego Is Nothing Then
                        Try
                            If Await helper.FileExistsAsync("Juegos\juego_" + juego.ID) = False Then
                                Await helper.SaveFileAsync(Of Tile)("Juegos\juego_" + juego.ID, juego)
                            End If
                        Catch ex As Exception

                        End Try

                        resultadosBusqueda.Add(New Interfaz.BusquedaFichero(juego.Titulo, "Juegos\juego_" + juego.ID))
                    End If
                Next
            End If
        End If

        Try
            Await helper.SaveFileAsync(Of List(Of Interfaz.BusquedaFichero))("busqueda", resultadosBusqueda)
        Catch ex As Exception

        End Try

        Dim gridJuegos As Grid = pagina.FindName("gridJuegos")
        Interfaz.Pestañas.Visibilidad(gridJuegos, recursos.GetString("Games"), Nothing)

        If Not listaJuegos Is Nothing Then
            If listaJuegos.Count > 0 Then
                listaJuegos.Sort(Function(x, y)
                                     If Not x Is Nothing Then
                                         If Not y Is Nothing Then
                                             Return x.Titulo.CompareTo(y.Titulo)
                                         End If
                                     End If

                                     If Not x Is Nothing Then
                                         Return x.Titulo
                                     End If

                                     If Not y Is Nothing Then
                                         Return y.Titulo
                                     End If

                                     Return Nothing
                                 End Function)

                gv.Items.Clear()

                For Each juego In listaJuegos
                    BotonEstilo(juego, gv)
                Next
            End If
        End If

        Cache.Estado(True)
        LimpiezaArchivos.Estado(True)

    End Sub

    Public Sub BotonEstilo(juego As Tile, gv As GridView)

        Dim imagen As New ImageEx With {
            .Source = juego.ImagenGrande,
            .IsCacheEnabled = True,
            .Stretch = Stretch.UniformToFill,
            .Padding = New Thickness(0, 0, 0, 0),
            .HorizontalAlignment = HorizontalAlignment.Center,
            .VerticalAlignment = VerticalAlignment.Center,
            .EnableLazyLoading = True
        }

        Dim boton As New Button With {
            .Tag = juego,
            .Content = imagen,
            .Padding = New Thickness(0, 0, 0, 0),
            .Background = New SolidColorBrush(Colors.Transparent),
            .Margin = New Thickness(10, 10, 10, 10),
            .MinHeight = 40,
            .MinWidth = 40,
            .MaxWidth = anchoColumna + 20,
            .BorderBrush = New SolidColorBrush(App.Current.Resources("ColorPrimario")),
            .BorderThickness = New Thickness(1, 1, 1, 1),
            .HorizontalAlignment = HorizontalAlignment.Center,
            .VerticalAlignment = VerticalAlignment.Center
        }

        Dim tbToolTip As TextBlock = New TextBlock With {
            .Text = juego.Titulo,
            .FontSize = 16,
            .TextWrapping = TextWrapping.Wrap
        }

        ToolTipService.SetToolTip(boton, tbToolTip)
        ToolTipService.SetPlacement(boton, PlacementMode.Mouse)

        AddHandler boton.Click, AddressOf BotonTile_Click
        AddHandler boton.PointerEntered, AddressOf Interfaz.Entra_Boton_Imagen
        AddHandler boton.PointerExited, AddressOf Interfaz.Sale_Boton_Imagen

        gv.Items.Add(boton)

    End Sub

    Private Sub BotonTile_Click(sender As Object, e As RoutedEventArgs)

        Trial.Detectar()
        Interfaz.AñadirTile.ResetearValores()

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Dim botonJuego As Button = e.OriginalSource
        Dim juego As Tile = botonJuego.Tag

        Dim botonAñadirTile As Button = pagina.FindName("botonAñadirTile")
        botonAñadirTile.Tag = juego

        Dim imagenJuegoSeleccionado As ImageEx = pagina.FindName("imagenJuegoSeleccionado")
        imagenJuegoSeleccionado.Source = juego.ImagenAncha

        Dim tbJuegoSeleccionado As TextBlock = pagina.FindName("tbJuegoSeleccionado")
        tbJuegoSeleccionado.Text = juego.Titulo

        Dim gridAñadirTile As Grid = pagina.FindName("gridAñadirTile")
        Interfaz.Pestañas.Visibilidad(gridAñadirTile, juego.Titulo, Nothing)

        '---------------------------------------------

        ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("animacionJuego", botonJuego)
        Dim animacion As ConnectedAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("animacionJuego")

        If Not animacion Is Nothing Then
            animacion.Configuration = New BasicConnectedAnimationConfiguration
            animacion.TryStart(gridAñadirTile)
        End If

        '---------------------------------------------

        Dim tbImagenTituloTextoTileAncha As TextBox = pagina.FindName("tbImagenTituloTextoTileAncha")
        tbImagenTituloTextoTileAncha.Text = juego.Titulo
        tbImagenTituloTextoTileAncha.Tag = juego.Titulo

        Dim tbImagenTituloTextoTileGrande As TextBox = pagina.FindName("tbImagenTituloTextoTileGrande")
        tbImagenTituloTextoTileGrande.Text = juego.Titulo
        tbImagenTituloTextoTileGrande.Tag = juego.Titulo

        '---------------------------------------------

        Dim imagenPequeña As ImageEx = pagina.FindName("imagenTilePequeña")
        imagenPequeña.Source = Nothing

        Dim imagenMediana As ImageEx = pagina.FindName("imagenTileMediana")
        imagenMediana.Source = Nothing

        Dim imagenAncha As ImageEx = pagina.FindName("imagenTileAncha")
        imagenAncha.Source = Nothing

        Dim imagenGrande As ImageEx = pagina.FindName("imagenTileGrande")
        imagenGrande.Source = Nothing

        If Not juego.ImagenPequeña Is Nothing Then
            imagenPequeña.Source = juego.ImagenPequeña
            imagenPequeña.Tag = juego.ImagenPequeña
        End If

        If Not juego.ImagenMediana Is Nothing Then
            imagenMediana.Source = juego.ImagenMediana
            imagenMediana.Tag = juego.ImagenMediana
        End If

        If Not juego.ImagenAncha = Nothing Then
            imagenAncha.Source = juego.ImagenAncha
            imagenAncha.Tag = juego.ImagenAncha
        End If

        If Not juego.ImagenGrande = Nothing Then
            imagenGrande.Source = juego.ImagenGrande
            imagenGrande.Tag = juego.ImagenGrande
        End If

    End Sub

    Private Sub UsuarioEntraBoton(sender As Object, e As PointerRoutedEventArgs)

        Dim boton As Button = sender
        boton.Saturation(0).Scale(1.05, 1.05, boton.ActualWidth / 2, boton.ActualHeight / 2).Start()

        Window.Current.CoreWindow.PointerCursor = New CoreCursor(CoreCursorType.Hand, 1)

    End Sub

    Private Sub UsuarioSaleBoton(sender As Object, e As PointerRoutedEventArgs)

        Dim boton As Button = sender
        boton.Saturation(1).Scale(1, 1, boton.ActualWidth / 2, boton.ActualHeight / 2).Start()

        Window.Current.CoreWindow.PointerCursor = New CoreCursor(CoreCursorType.Arrow, 1)

    End Sub

End Module
