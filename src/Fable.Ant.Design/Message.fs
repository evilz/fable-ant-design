namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props



[<RequireQualifiedAccess>]
module Message =

    type MessageConfig = {
        duration:float // time before auto-dismiss, in seconds
        getContainer: unit -> Browser.HTMLElement // Return the mount node for Message
        top:int // distance from top
        maxCount:int // max message show, drop oldest if exceed limit
    }

    type IMessage = 
        abstract success : string -> unit
        [<Emit("$0.success($1,$2)")>]
        abstract success' : string * float -> unit
        [<Emit("$0.success($1,$2)")>]
        abstract success'' : string * float * (unit-> unit)  -> unit

        abstract error : string -> unit
        [<Emit("$0.error($1,$2)")>]
        abstract error' : string * float -> unit
        [<Emit("$0.error($1,$2)")>]
        abstract error'' : string * float * (unit-> unit)  -> unit

        abstract info : string -> unit
        [<Emit("$0.info($1,$2)")>]
        abstract info' : string * float -> unit
        [<Emit("$0.info($1,$2)")>]
        abstract info'' : string * float * (unit-> unit)  -> unit

        abstract warning : string -> unit
        [<Emit("$0.warning($1,$2)")>]
        abstract warning' : string * float -> unit
        [<Emit("$0.warning($1,$2)")>]
        abstract warning'' : string * float * (unit-> unit)  -> unit

        abstract loading : string -> unit
        [<Emit("$0.loading($1,$2)")>]
        abstract loading' : string * float -> unit
        [<Emit("$0.loading($1,$2)")>]
        abstract loading'' : string * float * (unit-> unit)  -> unit

        abstract destroy: unit  -> unit
        abstract config: MessageConfig  -> unit


    let message = import "message" "antd" :> IMessage