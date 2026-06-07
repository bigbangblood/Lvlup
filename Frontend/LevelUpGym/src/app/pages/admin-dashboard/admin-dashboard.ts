import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './admin-dashboard.html',
  styleUrl: './admin-dashboard.css',
})
export class AdminDashboardComponent implements OnInit {
  private http = inject(HttpClient);
  private authService = inject(AuthService);
  private router = inject(Router);

  clients = signal<any[]>([]);
  totalRevenue = signal<number>(0);
  newMembersCount = signal<number>(0);

  activeTab = 'resumen';

  ngOnInit() {
    // Validate if logged-in user is admin
    const currentUser = this.authService.currentUser();
    if (!currentUser || currentUser.email !== 'admin@levelup.com') {
      this.router.navigate(['/login']);
      return;
    }

    this.loadStats();
  }

  loadStats() {
    // Fetch clients
    this.http.get<any[]>('http://localhost:5143/api/clients').subscribe({
      next: (data) => {
        this.clients.set(data);
        this.newMembersCount.set(data.length);
      }
    });

    // Revenue information unavailable after store removal
    this.totalRevenue.set(0);
  }

  setTab(tab: string) {
    this.activeTab = tab;
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
