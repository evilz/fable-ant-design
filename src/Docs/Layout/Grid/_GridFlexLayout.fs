module Layout.Grid.GridFlexLayout
open Fable.Helpers.React
open Fable.AntD

let view () = 
    div [ ] [
      p [ ] [ str "sub-element align left" ]
      Grid.row [ Grid.Type Grid.Flex; Grid.Justify Grid.Start ] [
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
      ]

      p [ ] [ str "sub-element align center" ]
      Grid.row [ Grid.Type Grid.Flex; Grid.Justify Grid.Center ] [
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
      ]

      p [ ] [ str "sub-element align right" ]
      Grid.row [ Grid.Type Grid.Flex; Grid.Justify Grid.End ] [
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
      ]

      p [ ] [ str "sub-element monospaced arrangement" ]
      Grid.row [ Grid.Type Grid.Flex; Grid.Justify Grid.SpaceBetween ] [
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
      ]

      p [ ] [ str "sub-element align full" ]
      Grid.row [ Grid.Type Grid.Flex; Grid.Justify Grid.SpaceAround ] [
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
        Grid.col [ Grid.Span 4 ] [str "col-4" ]
      ]
    ]