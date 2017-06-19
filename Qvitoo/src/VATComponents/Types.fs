module VATComponents.Types

type Msg =
  | SetTotalTax of value:float
  | SetMultiTaxes of enabled:bool

type Rate =
  { n: int
    d: int }

type Model =
  { rates: Rate list
    totalTaxes: float option
    isMulti: bool
  }