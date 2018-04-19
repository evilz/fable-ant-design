module Layout.Grid.GridFlexAlignment
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let DemoBox height children = div [  ] children 

let view () = 
    div [ ] [
      p [ ] [ str "Align Top" ]
      Grid.row [ Grid.Type Grid.Flex; Grid.Justify Grid.Center; Grid.Align Grid.Top ] [
        Grid.col [ Grid.Span 4 ] [ DemoBox 100 [str "col-4" ] ]
        Grid.col [ Grid.Span 4 ] [ DemoBox 50 [str "col-4" ] ]
        Grid.col [ Grid.Span 4 ] [ DemoBox 120 [str "col-4" ] ]
        Grid.col [ Grid.Span 4 ] [ DemoBox 80 [str "col-4" ] ]
      ]
    ]