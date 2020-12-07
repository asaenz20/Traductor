import { Component, OnInit } from '@angular/core';
import { TraductorService } from '../traductor.service';

@Component({
  selector: 'app-traducir',
  templateUrl: './traducir.component.html'
})
export class TraducirComponent implements OnInit {

  public frase: any;
  public audio: string;

  constructor(public traductorService: TraductorService) {

  }

  ngOnInit(): void {
  }

  traducir(fraseE: string, idioma: string) {
    //Obtener la traduccion
    this.traductorService.obtenerTraduccion(fraseE, idioma).
      subscribe(data => {
        this.frase = data;
      });
    //obtener el audio
    this.traductorService.obtenerAudio(fraseE, idioma).
      subscribe(data => {
        this.audio = 'data:audio/mp3;base64,' + data;
      });
  }

}
