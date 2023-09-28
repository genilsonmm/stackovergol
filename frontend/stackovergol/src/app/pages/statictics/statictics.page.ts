import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

@Component({
  selector: 'app-statictics',
  templateUrl: './statictics.page.html',
  styleUrls: ['./statictics.page.scss'],
  standalone: true,
  imports: [IonicModule, CommonModule, FormsModule]
})
export class StaticticsPage implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
