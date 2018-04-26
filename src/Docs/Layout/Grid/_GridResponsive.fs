module Layout.Grid.GridResponsive
open Fable.Core
open Fable.Helpers.React
open Fable.AntD

let view () = 
    div [ ] [
      p [] [ str "Simple number"]
      Grid.row [ ] [
        Grid.col [ Grid.Xs (U2.Case1 2);  Grid.Sm (U2.Case1 6);  Grid.Md (U2.Case1 6); Grid.Lg (U2.Case1 8); Grid.Xl (U2.Case1 10) ] [str "col" ]
        Grid.col [ Grid.Xs (U2.Case1 20); Grid.Sm (U2.Case1 12); Grid.Md (U2.Case1 12);Grid.Lg (U2.Case1 8); Grid.Xl (U2.Case1 4) ] [str "col" ]
        Grid.col [ Grid.Xs (U2.Case1 2);  Grid.Sm (U2.Case1 6);  Grid.Md (U2.Case1 6); Grid.Lg (U2.Case1 8); Grid.Xl (U2.Case1 10) ] [str "col" ]
      ]

      p [] [ str "Complex responsive settings"]
      Grid.row [ ] [
        Grid.col [ Grid.Xs (U2.Case2 (Grid.ColSize.ofTuple(5,-1,1,-1,1)));  Grid.Lg (U2.Case2 (Grid.ColSize.ofTuple(6,-1,2,-1,1))) ] [str "col" ]
        Grid.col [ Grid.Xs (U2.Case2 (Grid.ColSize.ofTuple(11,-1,1,-1,1)));  Grid.Lg (U2.Case2 (Grid.ColSize.ofTuple(6,-1,2,-1,1))) ] [str "col" ]
        Grid.col [ Grid.Xs (U2.Case2 (Grid.ColSize.ofTuple(5,-1,1,-1,1)));  Grid.Lg (U2.Case2 (Grid.ColSize.ofTuple(6,-1,2,-1,1))) ] [str "col" ]
      ]
     ]
