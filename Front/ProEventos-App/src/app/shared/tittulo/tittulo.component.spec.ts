import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TittuloComponent } from './tittulo.component';

describe('TittuloComponent', () => {
  let component: TittuloComponent;
  let fixture: ComponentFixture<TittuloComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ TittuloComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TittuloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
