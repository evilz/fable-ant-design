module Layout.Grid.GridSort
open Fable.Helpers.React
open Fable.AntD

let view () = 
    div [ ] [
      Grid.row [ ] [
        Grid.col [ Grid.Span 18; Grid.Push 6 ] [str "col-18 col-push-6" ]
        Grid.col [ Grid.Span 6; Grid.Pull 18 ] [str "col-6 col-pull-18" ]
      ]
    ]