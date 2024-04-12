import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  Cargo,
  Departamento,
  TipoModificador,
  Usuario,
} from '@users/models/user.model';
import { DepartmentsService } from '@users/services/departments.service';
import { UsersService } from '@users/services/users.service';
import { WorkstationsService } from '@users/services/workstations.service';
import { MessageService } from 'primeng/api';
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
})
export class UserComponent {
  @Input() visible: boolean = false;
  @Input() tipo: TipoModificador;
  @Output() onHide: EventEmitter<any> = new EventEmitter();

  // User
  @Input() user: Usuario = null;
  formUser: FormGroup;

  // Dropdown
  departmentList: Departamento[];
  workStationList: Cargo[];

  constructor(
    private fb: FormBuilder,
    private deptService: DepartmentsService,
    private wsService: WorkstationsService,
    private userService: UsersService,
    private messageService: MessageService
  ) {}

  ngOnInit() {
    this.formGroupUser();

    this.deptService.getAllDepartments().subscribe((data) => {
      this.departmentList = data as Departamento[];
    });

    this.wsService.getAllWorkStations().subscribe((data) => {
      this.workStationList = data as Cargo[];
    });
  }

  onHideDialog(value: any = null): void {
    this.onHide.emit(null);
  }

  formGroupUser() {
    this.formUser = this.fb.group({
      id: [''],
      usuario: [''],
      email: [''],
      primerNombre: ['', [Validators.required]],
      segundoNombre: [''],
      primerApellido: ['', [Validators.required]],
      segundoApellido: [''],
      idDepartamento: ['', [Validators.required]],
      idCargo: ['', [Validators.required]],
    });

    if (this.user) this.formUser.patchValue(this.user);
  }

  onSaveUser(): void {
    const user = this.formUser.value;
    this.tipo == TipoModificador.Crear
      ? this.createUser(user)
      : this.updateUser(user);
  }

  createUser(user: any): void {
    delete user.id;
    this.userService.createUser(user).subscribe((u) => {
      this.onHideDialog();
      this.messageService.add({
        severity: 'success',
        summary: 'Successful',
        detail: 'Usuario Creado',
        life: 3000,
      });
    });
  }

  updateUser(user: any): void {
    this.userService.updateUser(user.id, user).subscribe((u) => {
      this.onHideDialog();
      this.messageService.add({
        severity: 'success',
        summary: 'Successful',
        detail: 'Usuario Editado',
        life: 3000,
      });
    });
  }
}
