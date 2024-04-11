import { Component } from '@angular/core';
import { TipoModificador } from '@users/models/user.model';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
})
export class UsersComponent {
  cols: any[];
  users!: any[];
  user!: any;
  selectedUsers!: any[] | null;

  showUserDialog: boolean = false;
  typeModifierDialog: TipoModificador;

  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit() {
    this.loadUserDataTable();
  }

  loadUserDataTable(): void {
    this.cols = [
      { header: 'Usuario', field: 'usuario' },
      { header: 'Nombres', field: 'nombres' },
      { header: 'Apellidos', field: 'apellidos' },
      { header: 'Departamento', field: 'departamento' },
      { header: 'Cargo', field: 'cargo' },
      { header: 'Email', field: 'email' },
      { header: 'Acciones', field: 'acciones' },
    ];

    this.users = [
      {
        usuario: 'asdas',
      },
    ];
  }

  onHideDialog() {
    this.showUserDialog = false;
    this.typeModifierDialog = null;
  }

  createUser() {
    this.showUserDialog = true;
    this.typeModifierDialog = TipoModificador.Crear;
  }

  editUser(user) {
    this.showUserDialog = true;
    this.typeModifierDialog = TipoModificador.Editar;
  }

  deleteUser(user) {
    this.confirmationService.confirm({
      message: '¿Estás seguro que deseas eliminar el usuario?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Usuario Eliminado',
          life: 3000,
        });
      },
    });
  }
}
