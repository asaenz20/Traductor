import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TraductorService {

  url: string;

  constructor(private http: HttpClient) {
    this.url = "https://localhost:44304/api/traduccion";
  }

  //Metodo que consume el metodo web GET
  obtenerTraduccion(fraseE: string, idioma: string) {
    let urlT = this.url+"?fraseespanol="+fraseE+"&idioma="+idioma+"&tipo=1";
    return this.http.get(urlT);
  }

  obtenerAudio(fraseE: string, idioma: string) {
    let urlT = this.url+"?fraseespanol="+fraseE+"&idioma="+idioma+"&tipo=2";
    return this.http.get(urlT);
  }

}
