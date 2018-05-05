namespace Layout.Grid

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open DemoCard.Types

module Types =

    [<StringEnum>]
    type GridDemos = Basic | Gutter | Offset | Sort | FlexLayout | FlexAlignment | FlexOrder | Responsive
    type Model = Map<GridDemos,DemoCard.Types.Tab> 

    type Msg =
      | ChangeTabMsg of GridDemos * DemoCard.Types.Tab

open Types

module State =

    let init () : Model * Cmd<Msg> =
      [Basic; Gutter; Offset; Sort; FlexLayout; FlexAlignment; FlexOrder; Responsive]
      |> List.map (fun x->x,DemoCard.Types.Demo) 
      |>  Map.ofList , Cmd.Empty

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (demo,tab) -> model.Add(demo, tab), []


module View =

    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    
    importAll "./Grid.less" 

    let demos =
        [|
          Basic, { title = "Basic Grid" ; 
            demo = Layout.Grid.BasicGrid.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_BasicGrid.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Gutter, { title = "Grid Gutter"; 
            demo = Layout.Grid.GridGutter.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridGutter.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          GridDemos.Offset, { title =  "Column offset"; 
            demo = Layout.Grid.GridOffset.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridOffset.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Sort, { title = "Grid Sort"; 
            demo = Layout.Grid.GridSort.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridSort.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          FlexLayout, { title = "Flex Layout"; 
            demo = Layout.Grid.GridFlexLayout.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridFlexLayout.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          FlexAlignment, { title = "Flex Alignment"; 
            demo = Layout.Grid.GridFlexAlignment.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridFlexAlignment.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          GridDemos.FlexOrder, { title = "Flex Order"; 
            demo = Layout.Grid.GridFlexOrder.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridFlexOrder.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Responsive, { title = "Responsive"; 
            demo = Layout.Grid.GridResponsive.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridResponsive.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          
        |] |> Map.ofArray

    let renderDemo dispatch (demos:Map<GridDemos,DemoCardModel>) (model:Model) demo  = 
      DemoCard.View.root {demos.[demo] with activeTab = model.[demo] }  (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 
          

    let root (model:Model) (dispatch:Msg->unit) =

      let renderDemo = renderDemo dispatch demos model
      div [ ClassName "grid-demo"  ] [
              yield h1 [] [str "Grid"] 
              yield! [ Basic; Gutter; GridDemos.Offset; Sort; FlexLayout; FlexAlignment; GridDemos.FlexOrder; Responsive]
                      |> List.map renderDemo
            ]
