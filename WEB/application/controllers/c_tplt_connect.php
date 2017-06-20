<?php
	 class C_tplt_connect extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLT_CONNECT.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLT_CONNECT.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tplt_connectid' =>  $this->input->get_post('tplt_connectid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'connectionenabled' =>   $this->input->get_post('connectionenabled', TRUE)
                ,'connecttype' =>   $this->input->get_post('connecttype', TRUE)
                ,'connectlimit' =>   $this->input->get_post('connectlimit', TRUE)
                ,'theserver' =>   $this->input->get_post('theserver', TRUE)
                ,'netaddr' =>   $this->input->get_post('netaddr', TRUE)
                ,'cspeed' =>   $this->input->get_post('cspeed', TRUE)
                ,'cdatabit' =>   $this->input->get_post('cdatabit', TRUE)
                ,'cparity' =>   $this->input->get_post('cparity', TRUE)
                ,'cstopbits' =>   $this->input->get_post('cstopbits', TRUE)
                ,'flowcontrol' =>   $this->input->get_post('flowcontrol', TRUE)
                ,'comportnum' =>   $this->input->get_post('comportnum', TRUE)
                ,'ipaddr' =>   $this->input->get_post('ipaddr', TRUE)
                ,'portnum' =>   $this->input->get_post('portnum', TRUE)
                ,'username' =>   $this->input->get_post('username', TRUE)
                ,'password' =>   $this->input->get_post('password', TRUE)
                ,'ctowncode' =>   $this->input->get_post('ctowncode', TRUE)
                ,'cphone' =>   $this->input->get_post('cphone', TRUE)
                ,'atcommand' =>   $this->input->get_post('atcommand', TRUE)
                ,'callerid' =>   $this->input->get_post('callerid', TRUE)
            );
            $tplt_connect = $this->m_tplt_connect->setRow($data);
            print json_encode($tplt_connect);
    }
    function newRow() {
            log_message('debug', 'TPLT_CONNECT.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tplt_connectid' =>  $this->input->get_post('tplt_connectid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'connectionenabled' =>   $this->input->get_post('connectionenabled', TRUE)
                ,'connecttype' =>   $this->input->get_post('connecttype', TRUE)
                ,'connectlimit' =>   $this->input->get_post('connectlimit', TRUE)
                ,'theserver' =>   $this->input->get_post('theserver', TRUE)
                ,'netaddr' =>   $this->input->get_post('netaddr', TRUE)
                ,'cspeed' =>   $this->input->get_post('cspeed', TRUE)
                ,'cdatabit' =>   $this->input->get_post('cdatabit', TRUE)
                ,'cparity' =>   $this->input->get_post('cparity', TRUE)
                ,'cstopbits' =>   $this->input->get_post('cstopbits', TRUE)
                ,'flowcontrol' =>   $this->input->get_post('flowcontrol', TRUE)
                ,'comportnum' =>   $this->input->get_post('comportnum', TRUE)
                ,'ipaddr' =>   $this->input->get_post('ipaddr', TRUE)
                ,'portnum' =>   $this->input->get_post('portnum', TRUE)
                ,'username' =>   $this->input->get_post('username', TRUE)
                ,'password' =>   $this->input->get_post('password', TRUE)
                ,'ctowncode' =>   $this->input->get_post('ctowncode', TRUE)
                ,'cphone' =>   $this->input->get_post('cphone', TRUE)
                ,'atcommand' =>   $this->input->get_post('atcommand', TRUE)
                ,'callerid' =>   $this->input->get_post('callerid', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tplt_connect= $this->m_tplt_connect->newRow($instanceid,$data);
            $return = $tplt_connect;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLT_CONNECT.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tplt_connect = $this->m_tplt_connect->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tplt_connect
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'connecttype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tplt_connect= $this->m_tplt_connect->getRowsByInstance($instanceid,$sort);
                }else{
                    $tplt_connect= $this->m_tplt_connect->getRows($sort);
                }
            }else{
              $tplt_connect= $this->m_tplt_connect->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_connect
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLT_CONNECT.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'connecttype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tplt_connect= $this->m_tplt_connect->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_connect
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPLT_CONNECT.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'connecttype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tplt_connect= $this->m_tplt_connect->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tplt_connect
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPLT_CONNECT.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tplt_connectid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tplt_connect->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tplt_connect', 'm_tplt_connect');
    }
}
?>