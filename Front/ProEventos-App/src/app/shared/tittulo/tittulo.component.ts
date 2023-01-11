import { Component, Input,  OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tittulo',
  templateUrl: './tittulo.component.html',
  styleUrls: ['./tittulo.component.scss']
})
export class TittuloComponent implements OnInit {

  @Input() titulo: string = '';
  @Input() subtitulo: string = 'Desde de 2022';
  @Input() iconClass: string = 'fa fa-user';
  @Input() botaoListar: boolean = false;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  listar(): void {
    this.router.navigate([`/${this.titulo.toLocaleLowerCase()}/lista`])
  }

  public insereTitulo(value: string){
    this.titulo = value;
  }

}
