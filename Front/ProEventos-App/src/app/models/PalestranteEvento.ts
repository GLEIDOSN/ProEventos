import { Evento } from "./Evento";
import { Palestrante } from "./Palestrante";

export interface PalestranteEvento {
  palestranteId: Number;
  palestrante: Palestrante[];
  enventoId: Number;
  evento: Evento[];
}
