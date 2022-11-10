import { Component, Input,  OnInit } from '@angular/core';

@Component({
  selector: 'app-tittulo',
  templateUrl: './tittulo.component.html',
  styleUrls: ['./tittulo.component.scss']
})
export class TittuloComponent implements OnInit {

  @Input() titulo: string = '';

  constructor() { }

  ngOnInit(): void {
  }

  public insereTitulo(value: string){
    this.titulo = value;
  }

}
