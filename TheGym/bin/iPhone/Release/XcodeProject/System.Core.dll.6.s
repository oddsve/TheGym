.text
	.align 3
methods:
	.space 16
.text
	.align 2
L_m_0:
	.no_dead_strip System_Runtime_CompilerServices_ExtensionAttribute__ctor
System_Runtime_CompilerServices_ExtensionAttribute__ctor:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_0:
.text
	.align 3
methods_end:
.text
	.align 3
code_offsets:

.LDIFF_SYM0=L_m_0 - methods
	.long .LDIFF_SYM0
	.long -1

.text
	.align 3
method_info_offsets:

	.long 2,10,1,2
	.short 0
	.byte 1,255,255,255,255,255
.text
	.align 3
extra_method_table:

	.long 11,0,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0
.text
	.align 3
extra_method_info_offsets:

	.long 0
.text
	.align 3
class_name_table:

	.short 11, 1, 0, 0, 0, 0, 0, 0
	.short 0, 2, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0
.text
	.align 3
got_info_offsets:

	.long 3,10,1,2
	.short 0
	.byte 3,2,1
.text
	.align 3
ex_info_offsets:

	.long 2,10,1,2
	.short 0
	.byte 7,255,255,255,255,249
.text
	.align 3
unwind_info:

	.byte 18,12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
.text
	.align 3
class_info_offsets:

	.long 2,10,1,2
	.short 0
	.byte 10,7

.text
	.align 4
plt:
_mono_aot_System_Core_plt:
plt_end:
.text
	.align 3
image_table:

	.long 2
	.asciz "System.Core"
	.asciz "CCC35E45-7A41-4C72-9D35-7D70DF3B0E35"
	.asciz ""
	.asciz "7cec85d7bea7798e"
	.align 3

	.long 1,2,0,5,0
	.asciz "mscorlib"
	.asciz "7A97027E-5634-47A1-9086-BBBE7B399EAE"
	.asciz ""
	.asciz "7cec85d7bea7798e"
	.align 3

	.long 1,2,0,5,0
.data
	.align 3
_mono_aot_System_Core_got:
	.space 16
got_end:
.text
	.align 2
assembly_guid:
	.asciz "CCC35E45-7A41-4C72-9D35-7D70DF3B0E35"
.text
	.align 2
runtime_version:
	.asciz ""
.text
	.align 2
assembly_name:
	.asciz "System.Core"
.data
	.align 3
mono_aot_file_info:

	.long 75,0
	.align 2
	.long _mono_aot_System_Core_got
	.align 2
	.long methods
	.align 2
	.long 0
	.align 2
	.long blob
	.align 2
	.long class_name_table
	.align 2
	.long class_info_offsets
	.align 2
	.long method_info_offsets
	.align 2
	.long ex_info_offsets
	.align 2
	.long code_offsets
	.align 2
	.long extra_method_info_offsets
	.align 2
	.long extra_method_table
	.align 2
	.long got_info_offsets
	.align 2
	.long methods_end
	.align 2
	.long unwind_info
	.align 2
	.long mem_end
	.align 2
	.long image_table
	.align 2
	.long plt
	.align 2
	.long plt_end
	.align 2
	.long assembly_guid
	.align 2
	.long runtime_version
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long globals
	.align 2
	.long assembly_name

	.long 3,16,1,2,2,51456511,68,1024
	.long 1024,128,0,0,0,0,0,0
	.long 4,4
	.globl _mono_aot_module_System_Core_info
_mono_aot_module_System_Core_info:
	.align 2
	.long mono_aot_file_info
.text
	.align 3
blob:

	.byte 0,0,0,12,0,39,42,2,0,0,0,128,144,8,0,0,1,11,128,144,8,0,0,1,193,0,13,95,193,0,3,3
	.byte 193,0,13,91,193,0,3,16,193,0,2,228,193,0,2,229,193,0,2,230,193,0,2,231,193,0,3,15,193,0,3,4
	.byte 193,0,2,232,98,111,101,104,109,0
.text
	.align 3
Lglobals_hash:

	.short 11, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0
.data
	.align 3
globals:
	.align 2
	.long Lglobals_hash

	.long 0,0
.text
	.align 3
mem_end:
