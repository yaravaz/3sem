.586P
.MODEL flat, STDCALL

includelib kernel32.lib
includelib libucrt.lib

ExitProcess			PROTO: DWORD
SetConsoleTitleA	PROTO: DWORD
GetStdHandle		PROTO: DWORD
WriteConsoleA		PROTO: DWORD, : DWORD, : DWORD, : DWORD, : DWORD
EXTRN getmin: PROC
EXTRN getmax: PROC

.STACK 4096

.CONST 

.DATA
myDoubles				DD 1, 2, 3, 4, 5, 6, 7, 8, 5, 3

head			db 'Ассемблер', 0
text			db "getmax + getmin = ", 0
sum				dd 0
consolehandle	DD 0h

.CODE
main PROC
START:

	invoke SetConsoleTitleA, offset head

	push -11
	call GetStdHandle
	mov consolehandle, eax

	push lengthof MyDoubles
	push offset myDoubles
	call getmin

	mov sum, eax

	push lengthof MyDoubles
	push offset myDoubles
	call getmax

	add sum, eax
	add sum, 30h
	mov eax, sum

	mov text + 18, al

	invoke WriteConsoleA, consolehandle, offset text, sizeof text, 0, 0

	push 0
	call ExitProcess

main ENDP

END main