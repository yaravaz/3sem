.586P
.MODEL flat, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA
	myDoubles	dd	1, 2, 3, 4, 5, 6, 7, 8, 9, 3

	min dd ?
	max dd ?

	head	db "Ассемблер", 0
	text	db "min:  , max:  ", 0
	MB_OK EQU 0
	HW dw ?

.CODE
main PROC
START:

	push lengthof MyDoubles
	push offset MyDoubles
	call getmin
	mov min, eax

	push lengthof MyDoubles
	push offset MyDoubles
	call getmax
	mov max, eax


	mov eax, min
	add eax, 30h
	mov text + 5, al

	mov eax, max
	add eax, 30h
	mov text + 13, al

	INVOKE MessageBoxA, HW, offset text, offset head, MB_OK
	push 0
	call ExitProcess
	main ENDP


; --------------------- getmin ------------------

getmin PROC uses ecx esi ebx, pointer: dword, count: dword

	mov esi, pointer
	mov ecx, count
	mov eax, [esi]
CYCLE:
	mov ebx, [esi]
	add esi, 4
	
	cmp eax, ebx
	jl false
	mov eax, ebx

false:
	loop CYCLE

	ret
getmin ENDP

; --------------------- getmax ------------------ 

getmax PROC uses ecx ebx esi, pointer: dword, count: dword

	mov esi, pointer
	mov ecx, count
	mov eax, [esi]
CYCLE:
	mov ebx, [esi]
	add esi, 4
	
	cmp ebx, eax
	jl false
	mov eax, ebx

false:
	loop CYCLE

	ret
getmax ENDP


END main