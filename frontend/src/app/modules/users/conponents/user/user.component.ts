import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TipoModificador } from '@users/models/user.model';
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
})
export class UserComponent {
  @Input() visible: boolean = false;
  @Input() tipo: TipoModificador;
  @Output() onHide: EventEmitter<any> = new EventEmitter();

  // User
  @Input() user: any = null;
  formUser: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.formGroupUser();
  }

  onHideDialog(value: any = null): void {
    this.onHide.emit({ onClose: true, value });
  }

  formGroupUser() {
    this.formUser = this.fb.group({
      usuario: [''],
      email: [''],
      primerNombre: ['', [Validators.required]],
      segundoNombre: [''],
      primerApellido: ['', [Validators.required]],
      segundoApellido: [''],
      idDepartamento: ['', [Validators.required]],
      idCargo: ['', [Validators.required]],
    });

    if (this.user) this.formGroupUser.apply(this.user);
  }


}
