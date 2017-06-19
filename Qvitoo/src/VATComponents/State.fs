module VATComponents.State

open Elmish
open Types

let init (): Model * Cmd<Msg> =
  let model =
    { rates = []
      totalTaxes = None
      isMulti = false }

  model, []

let update msg model =
  match msg with
  | Msg.SetTotalVat ->
    model, []
  | Msg.SetMultiTaxes enabled ->
    model, []