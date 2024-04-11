import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmationService, MessageService, SharedModule } from 'primeng/api';

import { InputMaskModule } from 'primeng/inputmask';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { SlideMenuModule } from 'primeng/slidemenu';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { TabMenuModule } from 'primeng/tabmenu';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { DropdownModule } from 'primeng/dropdown';
import { TableModule } from 'primeng/table';
import { ToolbarModule } from 'primeng/toolbar';

var components = [
  CommonModule,
  SharedModule,
  InputMaskModule,
  ButtonModule,
  InputTextModule,
  SlideMenuModule,
  ConfirmDialogModule,
  TabMenuModule,
  MessagesModule,
  MessageModule,
  DialogModule,
  DropdownModule,
  TableModule,
  ToolbarModule,
];

@NgModule({
  declarations: [],
  imports: components,
  exports: components,
  providers: [MessageService, ConfirmationService],
})
export class PrimengModule {}
