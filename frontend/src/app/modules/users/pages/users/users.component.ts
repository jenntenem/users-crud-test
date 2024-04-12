import { Component } from '@angular/core';
import {
  Cargo,
  Departamento,
  TipoModificador,
  Usuario,
} from '@users/models/user.model';
import { ConfirmationService, MessageService } from 'primeng/api';
import { UsersService } from '../../services/users.service';
import { DepartmentsService } from '../../services/departments.service';
import { WorkstationsService } from '@users/services/workstations.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
})
export class UsersComponent {
  cols: any[];
  users!: Usuario[];
  user!: Usuario;
  selectedUsers!: any[] | null;

  showUserDialog: boolean = false;
  typeModifierDialog: TipoModificador;

  departmentList: Departamento[];
  workStationList: Cargo[];
  idDepartamento: number;
  idCargo: number;

  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private userService: UsersService,
    private deptService: DepartmentsService,
    private wsService: WorkstationsService
  ) {}

  ngOnInit() {
    this.loadUserDataTable();
    this.loadUserData();

    this.deptService.getAllDepartments().subscribe((data) => {
      this.departmentList = data as Departamento[];
    });

    this.wsService.getAllWorkStations().subscribe((data) => {
      this.workStationList = data as Cargo[];
    });
  }

  loadUserDataTable(): void {
    this.cols = [
      { header: 'Usuario', field: 'usuario' },
      { header: 'Nombres', field: 'nombres' },
      { header: 'Apellidos', field: 'apellidos' },
      { header: 'Departamento', field: 'departamento' },
      { header: 'Cargo', field: 'cargo' },
      { header: 'Email', field: 'email' },
      { header: 'Estado', field: 'activo' },
      { header: 'Acciones', field: 'acciones' },
    ];
  }

  loadUserData(): void {
    this.userService.getAllUsers().subscribe((data) => {
      this.users = data as Usuario[];
      this.selectedUsers = data as Usuario[];
    });
  }

  onHideDialog() {
    this.showUserDialog = false;
    this.typeModifierDialog = null;
    this.user = null;

    this.idCargo = null;
    this.idDepartamento = null;
    this.loadUserData();
  }

  createUser() {
    this.showUserDialog = true;
    this.typeModifierDialog = TipoModificador.Crear;
  }

  editUser(user: Usuario) {
    this.showUserDialog = true;
    this.typeModifierDialog = TipoModificador.Editar;
    this.user = user;
  }

  deleteUser(user: Usuario) {
    this.confirmationService.confirm({
      message: '¿Estás seguro que deseas eliminar el usuario?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        await this.userService.deleteUser(user.id).subscribe((u) => {
          this.loadUserData();
        });

        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Usuario Eliminado',
          life: 3000,
        });
      },
    });
  }

  filterDataTable(): void {
    this.selectedUsers = this.users.filter((u) =>
      !this.idDepartamento && !this.idCargo
        ? true
        : this.idDepartamento && this.idCargo
        ? u.idDepartamento == this.idDepartamento && u.idCargo == this.idCargo
        : u.idDepartamento == this.idDepartamento || u.idCargo == this.idCargo
    );
  }
}
