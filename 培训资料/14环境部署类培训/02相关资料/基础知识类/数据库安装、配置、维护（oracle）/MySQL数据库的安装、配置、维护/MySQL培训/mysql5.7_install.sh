#!/bin/bash
# ******************************************************
# Author       : Fander.Chan
# Last modified: 2016-12-19 19:55
# Email        : juncong.chen@gtafe.com
# Filename     : mysql5.7_install.sh
# Version      : v1.2
# Description  : Test in CentOS6.5
# ******************************************************

# Variable
mysql_version=5.7.17

# Check if user is root
if [ "0" != "`id -u`" ]; then
    echo "Error: You must be root to run this script, please use root to install"
    exit 1
fi

# Input port,default is 3306
read  -p "Input a mysql port(default 3306):  "   mysql_port
if  [ ! -n "${mysql_port}" ] ;then  
    echo -e "\033[32m there is no input,so use default port 3306 \033[0m"
    mysql_port=3306
else
    expr "$mysql_port" + 0 &>/dev/null
    [[ "0" -eq "$?" && "1" -lt "${mysql_port}" && "65535" -gt "${mysql_port}" ]] || {
	    echo -e "\033[31m ERROR! Input is not valid! exit install \033[0m"
        exit 1		
	}
	if [ "`netstat -nlatp | grep \":${mysql_port}\" | grep LISTEN | wc -l`" != "0" ]; then
        echo -e "\033[31m ${mysql_port} port in used! exit install \033[0m"
        exit 1
    fi
fi

read  -p "Input the password(default root):  "   mysql_passwd
if  [ ! -n "${mysql_passwd}" ] ;then  
    echo -e "\033[32m there is no input,so use default password root \033[0m"
    mysql_passwd=root
fi
[ "${#mysql_passwd}" -lt "16" ] || {
    echo -e "\033[31m password length should be less than 16! \033[0m"
	exit 1
}

# Check if MySQL installed or not
#CHECK_INSTALLED1
CHECK_INSTALLED1=`ps -ef | grep mysqld | grep -v grep`
[ -n "${CHECK_INSTALLED1}" ] && echo -e "\033[31m ERROR! Detect MySQL is already installed by ->>> ps -ef | grep mysqld  \033[0m" && CHECK_INSTALLED1_STATUS=1
CHECK_INSTALLED2=`chkconfig --list | grep mysql`
[ -n "${CHECK_INSTALLED2}" ] && echo -e "\033[31m ERROR! Detect MySQL is already installed by ->>> chkconfig --list | grep mysql \033[0m" && CHECK_INSTALLED2_STATUS=1
which mysqld &>/dev/null
CHECK_INSTALLED3="$?"
[ "0" != "$?" ] && echo -e "\033[31m ERROR! Detect MySQL is already installed by ->>> which mysqld  \033[0m" && CHECK_INSTALLED3_STATUS=1
#CHECK_INSTALLED4
[ -d "/opt/mysql/mysql-${mysql_version}-linux-glibc2.5-x86_64" ] && echo -e "\033[31m ERROR! The /opt/mysql/mysql-${mysql_version}-linux-glibc2.5-x86_64 is already exist! \033[0m" && CHECK_INSTALLED4_STATUS=1
#CHECK_INSTALLED5: if data directory is empty or not
CHECK_INSTALLED5="/data/mysql/mysql${mysql_port}/"
[ -d "${CHECK_INSTALLED4}" ] && echo -e "\033[31m ERROR! /data/mysql/mysql${mysql_port}/ is already exist! pls remove them first! \033[0m" && CHECK_INSTALLED5_STATUS=1

[[ "${CHECK_INSTALLED1_STATUS}" != "1" && "${CHECK_INSTALLED2_STATUS}" != "1" && "${CHECK_INSTALLED3_STATUS}" != "1" && "${CHECK_INSTALLED4_STATUS}" != "1" && "${CHECK_INSTALLED5_STATUS}" != "1" ]] || {
    echo -e "\033[31m exit install! \033[0m"
    exit 1
}

mysql_server_id=$(ip addr show|awk -F'[./]' '/inet / && !/127.0.0.1/{print $4}')${mysql_port}
expr "${mysql_server_id}" + 0 &>/dev/null
[[ "0" -eq "$?" && "1" -lt "${mysql_server_id}" && "25565535" -gt "${mysql_server_id}" ]] || {
	    echo -e "\033[31m ERROR! When the script get mysql_server_id,it is return wrong number! Pls check the script code \033[0m"
        exit 1		
}

# Disable iptables
/etc/init.d/iptables stop
chkconfig iptables off

# Disable selinux
getenforce 0
sed -i '/SELINUX/s/enforcing/disabled/' /etc/selinux/config 2>/dev/null

# Download 5.7 tar.gz package if not exist
# If using minimal-install,we should install wget and libaio library
yum install wget -y
yum install libaio -y
if [ ! -f "mysql-${mysql_version}-linux-glibc2.5-x86_64.tar.gz" ]; then 
  wget http://dev.mysql.com/get/Downloads/MySQL-5.7/mysql-${mysql_version}-linux-glibc2.5-x86_64.tar.gz
fi

tar zxvf mysql-${mysql_version}-linux-glibc2.5-x86_64.tar.gz
mkdir -p /opt/mysql/
mv mysql-${mysql_version}-linux-glibc2.5-x86_64 /opt/mysql/
ln -s /opt/mysql/mysql-${mysql_version}-linux-glibc2.5-x86_64 /usr/local/mysql


# Create user mysql, group mysql
groupadd mysql 
useradd -M -g mysql -s /sbin/nologin -d /usr/local/mysql mysql
mkdir -p /data/mysql/mysql${mysql_port}/{data,logs,tmp}
touch /data/mysql/mysql${mysql_port}/my.cnf
chown -R mysql:mysql /data/mysql/mysql${mysql_port}/

# backup old my.cnf if exist
if [ -s /etc/my.cnf ]; then  
    mv /etc/my.cnf /etc/my.cnf.`date +%Y%m%d%H%M%S`.bak  
fi  

#cat >/data/mysql/mysql${mysql_port}/my.cnf <<EOF
cat >/etc/my.cnf <<EOF
#my.cnf
[client]
port            = ${mysql_port}
socket          = /tmp/mysql${mysql_port}.sock

[mysql]
prompt="\\u@\\h [\\d]>" 
auto-rehash

[mysqld]
user = mysql
basedir = /usr/local/mysql
datadir = /data/mysql/mysql${mysql_port}/data
port = ${mysql_port}
socket = /tmp/mysql${mysql_port}.sock
event_scheduler = 0
tmpdir = /data/mysql/mysql${mysql_port}/tmp

#timeout
interactive_timeout = 300
wait_timeout = 300

#character set
character-set-server = utf8

open_files_limit = 65535
max_connections = 100
max_connect_errors = 100000

#logs
log-output=file
slow_query_log = 1
slow_query_log_file = slow.log
log-error = /data/mysql/mysql${mysql_port}/error.log
log_warnings = 2
pid-file = /data/mysql/mysql${mysql_port}/mysql.pid
long_query_time = 1
#log-slow-admin-statements = 1
#log-queries-not-using-indexes = 1
log-slow-slave-statements = 1

#binlog
binlog_format = row
server-id = ${mysql_server_id}
log-bin = /data/mysql/mysql${mysql_port}/logs/mysql-bin
binlog_cache_size = 4M
max_binlog_size = 256M
max_binlog_cache_size = 1M
sync_binlog = 0
expire_logs_days = 10
#procedure 
log_bin_trust_function_creators=1

#
gtid-mode = 0

#relay log
skip_slave_start = 1
max_relay_log_size = 128M
relay_log_purge = 1
relay_log_recovery = 1
relay-log=relay-bin
relay-log-index=relay-bin.index
log_slave_updates
#slave-skip-errors=1032,1053,1062
#skip-grant-tables

#buffers & cache
table_open_cache = 2048
table_definition_cache = 2048
table_open_cache = 2048
max_heap_table_size = 96M
sort_buffer_size = 128K
join_buffer_size = 128K
thread_cache_size = 200
query_cache_size = 0
query_cache_type = 0
query_cache_limit = 256K
query_cache_min_res_unit = 512
thread_stack = 192K
tmp_table_size = 96M
key_buffer_size = 8M
read_buffer_size = 2M
read_rnd_buffer_size = 16M
bulk_insert_buffer_size = 32M

#myisam
myisam_sort_buffer_size = 128M
myisam_max_sort_file_size = 10G
myisam_repair_threads = 1

#innodb
innodb_buffer_pool_size = 100M
innodb_buffer_pool_instances = 1
innodb_data_file_path = ibdata1:100M:autoextend
innodb_flush_log_at_trx_commit = 2
innodb_log_buffer_size = 8M
innodb_log_file_size = 100M
innodb_log_files_in_group = 3
innodb_max_dirty_pages_pct = 50
innodb_file_per_table = 1
innodb_rollback_on_timeout
innodb_status_file = 1
innodb_io_capacity = 2000
transaction_isolation = READ-COMMITTED
innodb_flush_method = O_DIRECT

EOF

# Before MySQL 5.7.6 using mysql_install_db，MySQL 5.7.6 and up using mysqld  
#/usr/local/mysql/bin/mysqld --defaults-file=/data/mysql/mysql${mysql_port}/my.cnf --initialize-insecure
/usr/local/mysql/bin/mysqld --defaults-file=/etc/my.cnf --initialize-insecure

# Add as a service  
cp /usr/local/mysql/support-files/mysql.server /etc/init.d/mysql  
chmod 755 /etc/init.d/mysql  
chkconfig --add mysql  
chkconfig mysql on  
#/etc/init.d/mysql start
service mysql start
  
echo "PATH=/usr/local/mysql/bin:/usr/local/mysql/lib:$PATH
export PATH" >>/etc/profile
  
source /etc/profile  
  
# Change passwd  
mysqladmin -u root password ${mysql_passwd} -S /tmp/mysql${mysql_port}.sock
  
# We must re-login to reload the environment variables
echo -e "\033[32m set up successfully!enjoy it.... \033[0m"  
echo -e "\033[31m Please re-login your root account so that the environment variables can take effect. \033[0m" 

exit 0  
