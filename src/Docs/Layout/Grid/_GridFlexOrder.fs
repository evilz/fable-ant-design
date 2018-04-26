module Layout.Grid.GridFlexOrder
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let DemoBox height children = div [ Style [ Height (sprintf "%ipx" height);LineHeight (sprintf "%ipx" height);] ] children 

let view () = 
    div [ ] [
      p [ ] [ str "Align Top" ]
      Grid.row [ Grid.Type Grid.Flex ] [
        Grid.col [ Grid.Span 6; Grid.Order 4 ]  [ str "1 but order 4" ]
        Grid.col [ Grid.Span 6; Grid.Order 3  ] [ str "2 but order 3" ]
        Grid.col [ Grid.Span 6; Grid.Order 2  ] [ str "3 but order 2" ]
        Grid.col [ Grid.Span 6; Grid.Order 1  ] [ str "4 but order 1" ]
      ]
    ]