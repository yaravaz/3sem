.586P
.MODEL FLAT, STDCALL
.CODE

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


end