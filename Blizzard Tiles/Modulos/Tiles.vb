Imports Microsoft.Toolkit.Uwp.Notifications
Imports Microsoft.Toolkit.Uwp.UI.Controls
Imports Windows.Storage
Imports Windows.UI.Notifications
Imports Windows.UI.StartScreen

Module Tiles

    Public Async Sub Generar(tile As Tile)

        Dim nuevaTile As SecondaryTile = New SecondaryTile(tile.Titulo.Replace(" ", Nothing), tile.Titulo, tile.Enlace.ToString, tile.ImagenWide, TileSize.Wide310x150)

        nuevaTile.VisualElements.Wide310x150Logo = New Uri(tile.ImagenWide.AbsoluteUri, UriKind.RelativeOrAbsolute)
        'nuevaTile.VisualElements.Square310x310Logo = New Uri(tile.ImagenWide.AbsoluteUri, UriKind.RelativeOrAbsolute)

        Await nuevaTile.RequestCreateAsync()

        Dim imagenDRM As AdaptiveImage = Nothing

        If ApplicationData.Current.LocalSettings.Values("logotile") = "on" Then
            imagenDRM = New AdaptiveImage With {
                .HintRemoveMargin = True,
                .HintAlign = AdaptiveImageAlign.Right
            }

            Dim frame As Frame = Window.Current.Content
            Dim pagina As Page = frame.Content
            Dim cbIconosLista As ComboBox = pagina.FindName("cbTilesIconosLista")
            Dim imagenIcono As ImageEx = cbIconosLista.SelectedItem
            imagenDRM.Source = imagenIcono.Source

        End If

        Dim imagen As AdaptiveImage = New AdaptiveImage With {
            .Source = tile.ImagenWide.AbsoluteUri,
            .HintRemoveMargin = True,
            .HintAlign = AdaptiveImageAlign.Stretch,
            .HintCrop = AdaptiveImageCrop.Default
        }

        Dim fondoImagenWide As TileBackgroundImage = New TileBackgroundImage With {
            .Source = tile.ImagenWide.AbsoluteUri,
            .HintCrop = AdaptiveImageCrop.Default
        }

        Dim fondoImagenMedium As TileBackgroundImage = New TileBackgroundImage With {
            .Source = tile.ImagenMedium.AbsoluteUri,
            .HintCrop = AdaptiveImageCrop.Default
        }

        Dim fondoImagenSmall As TileBackgroundImage = New TileBackgroundImage With {
            .Source = tile.ImagenSmall.AbsoluteUri,
            .HintCrop = AdaptiveImageCrop.Default
        }

        '-----------------------

        Dim contenidoWide As TileBindingContentAdaptive = New TileBindingContentAdaptive With {
            .BackgroundImage = fondoImagenWide
        }

        If Not imagenDRM Is Nothing Then
            contenidoWide.Children.Add(imagenDRM)
        End If

        Dim tileWide As TileBinding = New TileBinding With {
            .Content = contenidoWide
        }

        '-----------------------

        Dim contenidoMedium As TileBindingContentAdaptive = New TileBindingContentAdaptive With {
            .BackgroundImage = fondoImagenMedium
        }

        If Not imagenDRM Is Nothing Then
            contenidoMedium.Children.Add(imagenDRM)
        End If

        Dim tileMedium As TileBinding = New TileBinding With {
            .Content = contenidoMedium
        }

        '-----------------------

        Dim contenidoSmall As TileBindingContentAdaptive = New TileBindingContentAdaptive With {
            .BackgroundImage = fondoImagenSmall
        }

        'If Not imagenDRM Is Nothing Then
        '    contenidoSmall.Children.Add(imagenDRM)
        'End If

        Dim tileSmall As TileBinding = New TileBinding With {
            .Content = contenidoSmall
        }

        '-----------------------

        Dim contenidoLarge As TileBindingContentAdaptive = New TileBindingContentAdaptive
        contenidoLarge.Children.Add(imagen)

        If Not imagenDRM Is Nothing Then
            contenidoLarge.Children.Add(imagenDRM)
        End If

        Dim tileLarge As TileBinding = New TileBinding With {
            .Content = contenidoLarge
        }

        '-----------------------

        If ApplicationData.Current.LocalSettings.Values("titulotile") = "on" Then
            tileWide.Branding = TileBranding.Name
            tileSmall.Branding = TileBranding.Name
            tileMedium.Branding = TileBranding.Name
            tileLarge.Branding = TileBranding.Name
        End If

        Dim visual As TileVisual = New TileVisual With {
            .TileWide = tileWide,
            .TileSmall = tileSmall,
            .TileMedium = tileMedium,
            .TileLarge = tileLarge
        }

        Dim contenido As TileContent = New TileContent With {
            .Visual = visual
        }

        Dim notificacion As TileNotification = New TileNotification(contenido.GetXml)

        Try
            TileUpdateManager.CreateTileUpdaterForSecondaryTile(tile.Titulo.Replace(" ", Nothing)).Update(notificacion)
        Catch ex As Exception

        End Try

    End Sub

End Module
