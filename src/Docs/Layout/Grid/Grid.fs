namespace Layout.Grid

open Fable.Core
open Fable.Core.JsInterop
open Elmish

module Types =

    type Model = Map<string,DemoCard.Types.Model> 

    type Msg =
      | ChangeTabMsg of string * DemoCard.Types.Tab

    [<StringEnum>]
    type Demos = Basic | Gutter | Offset | Sort | FlexLayout | FlexAlignment | FlexOrder | Responsive

    let getTitle = function
      | Basic -> "Basic Grid" 
      | Gutter -> "Grid Gutter"
      | Offset -> "Column offset"
      | Sort -> "Grid Sort"
      | FlexLayout -> "Flex Layout"
      | FlexAlignment -> "Flex Alignment"
      | FlexOrder -> "Flex Order"
      | Responsive -> "Responsive"

open Types

module State =

    let init () : Model * Cmd<Msg> =
    
      let demos:DemoCard.Types.Model[] =
        [|
          { title = Basic |> getTitle; 
            demo = Layout.Grid.BasicGrid.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_BasicGrid.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = Gutter |> getTitle; 
            demo = Layout.Grid.GridGutter.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridGutter.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = Offset |> getTitle; 
            demo = Layout.Grid.GridOffset.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridOffset.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = Sort |> getTitle; 
            demo = Layout.Grid.GridSort.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridSort.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = FlexLayout |> getTitle; 
            demo = Layout.Grid.GridFlexLayout.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridFlexLayout.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = FlexAlignment |> getTitle; 
            demo = Layout.Grid.GridFlexAlignment.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridFlexAlignment.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = FlexOrder |> getTitle; 
            demo = Layout.Grid.GridFlexOrder.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridFlexOrder.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          { title = Responsive |> getTitle; 
            demo = Layout.Grid.GridResponsive.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_GridResponsive.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          
        |]
    
      let model = demos
                    |> Seq.map (fun x -> x.title,x)
                    |> Map.ofSeq
        
      
      model , []

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (title,tab) ->
          model.Add(title, { model.[title] with DemoCard.Types.activeTab = tab}  ), []


module View =

    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    
    importAll "./Grid.less" 

    let renderDemo dispatch (demo:DemoCard.Types.Model)  = 
      DemoCard.View.root demo (fun msg -> ChangeTabMsg (demo.title, msg) |> dispatch  ) 
          

    let root (model:Model) (dispatch:Msg->unit) =

      let demos = [ Basic; Gutter; Types.Offset; Sort; FlexLayout; FlexAlignment; Demos.FlexOrder; Responsive]
      let renderDemo = renderDemo dispatch
      div [ ClassName "grid-demo"  ] [
              yield h1 [] [str "Grid"] 
              for demo in demos -> model.[(demo |> getTitle)] |> renderDemo
            ]
