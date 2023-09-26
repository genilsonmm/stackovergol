import { Injectable, WritableSignal, signal } from '@angular/core';
import { SQLiteConnection, CapacitorSQLite, SQLiteDBConnection } from '@capacitor-community/sqlite';

const DB_PLAYERS = 'playersdb'

export interface Player{
  id: number;
  name: string;
  rating: number;
}

@Injectable({
  providedIn: 'root'
})
export class DatabaseService {

  private sqlite: SQLiteConnection = new SQLiteConnection(CapacitorSQLite);
  private db!: SQLiteDBConnection;
  private players: WritableSignal<Player[]> = signal<Player[]>([]);

  constructor() { }

  async initialize(){
    this.db = await this.sqlite.createConnection(
      DB_PLAYERS,
      false,
      'no-encryption',
      1,
      false
    );

    await this.db.open();
    
    const schema = `CREATE TABLE IF NOT EXISTS players (
      id INTEGER PRIMARY KEY AUTOINCREMENT,
      name TEXT NOT NULL,
      rating INTEGER DEFAULT 1
    );`;

    await this.db.execute(schema);
    this.loadPlayers();
    return true;
  }

  async loadPlayers(){
    const players = await this.db.query('SELECT * FROM players;');
    this.players.set(players.values || []);
  }
}
