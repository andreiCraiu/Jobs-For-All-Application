import { Time } from "@angular/common";

export class Message {
    id!: number;
    content!: string;
    sendTime!: Date;
    senderId!: any;
    receiverId!: number;
    chatId!: number;
}