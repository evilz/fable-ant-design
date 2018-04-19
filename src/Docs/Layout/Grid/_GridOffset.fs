module Layout.Grid.GridOffset
open Fable.Helpers.React
open Fable.AntD

let view () = 
    div [ ] [
      Grid.row [ ] [
        Grid.col [ Grid.Span 8 ] [str "col-8" ]
        Grid.col [ Grid.Span 8; Grid.Offset 8 ] [str "col-8" ]
      ]
      Grid.row [ ] [
        Grid.col [ Grid.Span 6; Grid.Offset 6  ] [str "col-6 col-offset-6" ]
        Grid.col [ Grid.Span 6 ; Grid.Offset 6 ] [str "col-6 col-offset-6" ]
      ]
      Grid.row [ ] [
        Grid.col [ Grid.Span 12; Grid.Offset 6  ] [str "col-12 col-offset-6" ]
      ]
    ]