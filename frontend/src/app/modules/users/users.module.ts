import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UsersRoutingModule } from './users-routing.module';

// PrimeNG
import { PrimengModule } from '@primeng/primeng.module';

// Pages
import { UsersComponent } from './pages/users/users.component';

// Components
import { UserComponent } from './conponents/user/user.component';

@NgModule({
  declarations: [UsersComponent, UserComponent],
  imports: [
    CommonModule,
    UsersRoutingModule,
    PrimengModule,
    FormsModule,
    ReactiveFormsModule,
  ],
})
export class UsersModule {}
